using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.buyer
{
    public class Communication : BaseProcess
    {
        public bool Processed { get; set; }
        public override void Process(Update update)
        {
            if (update.Message != null)
            {
                var umci = update.Message.Chat.Id;
                var umm = update.Message.MessageId;
                var umt = update.Message.Text;
                var umrm = update.Message.ReplyToMessage.MessageId;

                Processed = false;
                var d = _db.Messages.FirstOrDefault(t => t.DestinationMessage == umrm && t.DUserId == umci);
                if (d != null)
                {
                    Processed = true;

                    var d1 = _db.Requests.FirstOrDefault(t => t.Id == d.RequestId);
                    var f = _db.Requests.Include("FieldId").FirstOrDefault(t => t.Id == d.RequestId).FieldId.Name;

                    //کاربری که پیام فرستاده خریدار است 
                    if (d1.UserId == umci)
                    {
                        //اگر خریدار در دیتابیس  خریدار وجود دارد
                        var e = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
                        if (e != null)
                        {
                            //var fieldName = _db.Buyers.Where(t => t.UserId == umci).Select(t => t.FieldId.Name).FirstOrDefault();
                            var firstname = e.FirstName;
                            var lastname = e.LastName;
                            var message = SendMessage(d.SUserId, update, t =>
                             {
                                 return string.Format(Farsi.SendMessageForAll, f, firstname, lastname != null ? "_" + lastname : "", t);
                             }, false, false, d.SourceMessage).Result.MessageId;
                            _db.Messages.Add(new Models.Message
                            {
                                SUserId = umci,
                                RequestId = d.RequestId,
                                SourceMessage = update.Message.MessageId,
                                DestinationMessage = message,
                                DUserId = d.SUserId
                            });
                            _db.SaveChanges();
                        }
                    }
                    //کاربری که پیام فرستاده فروشنده است 
                    else
                    {
                        var s = _db.Shops.FirstOrDefault(t => t.UserId == umci);
                        //اگر فروشگاه در دیتابیس هنوز باشد
                        if (s != null)
                        {
                            var shopname = s.Shop_name;
                            var message = SendMessage(d1.UserId, update, t =>
                              {
                                  return string.Format(Farsi.SellerToBuyer, f, shopname, t);
                              }, false, false, d.SourceMessage).Result.MessageId;
                            //var e = message - 1;
                            var q = new Models.Message
                            {
                                DUserId = d1.UserId,
                                RequestId = d.RequestId,
                                SourceMessage = update.Message.MessageId,
                                DestinationMessage = message,
                                SUserId = umci
                            };
                            _db.Messages.Add(q);
                            _db.SaveChanges();
                        }
                    }
                }
            }
            else if (update.EditedMessage != null)
            {

                var ueci = update.EditedMessage.Chat.Id;
                if (update.EditedMessage.ReplyToMessage != null)
                {
                    var d = _db.Messages.FirstOrDefault(t => t.SourceMessage == update.EditedMessage.MessageId && t.SUserId == ueci);
                    if (d != null)
                    {
                        Processed = true;
                        var d1 = _db.Requests.FirstOrDefault(t => t.Id == d.RequestId);
                        var f = _db.Requests.Include("FieldId").FirstOrDefault(t => t.Id == d.RequestId).FieldId.Name;

                        //کاربری که پیام را ویرایش کرده خریدار است 
                        if (d1.UserId == ueci)
                        {
                            //اگر خریدار در دیتابیس  خریدار وجود دارد
                            var e = _db.Buyers.FirstOrDefault(t => t.UserId == ueci);
                            if (e != null)
                            {
                                var firstname = e.FirstName;
                                var lastname = e.LastName;
                                //var fieldName = _db.Buyers.Where(t => t.UserId == ueci).Select(t => t.FieldId.Name).FirstOrDefault();
                                EditMessage(update, d.DUserId, d.DestinationMessage, t =>
                                    {
                                        return string.Format(Farsi.SendMessageForAll, f, firstname, lastname != null ? "_" + lastname : "", t);
                                    });
                            }
                        }
                        //کاربری که پیام فرستاده فروشنده است 
                        else
                        {
                            var s = _db.Shops.FirstOrDefault(t => t.UserId == ueci);
                            //اگر فروشگاه در دیتابیس هنوز باشد
                            if (s != null)
                            {
                                var shopname = s.Shop_name;

                                EditMessage(update, d1.UserId, d.DestinationMessage, t =>
                            {
                                return string.Format(Farsi.SellerToBuyer, f, shopname, t);
                            });
                            }
                        }
                    }
                }
                else
                {
                    var d = _db.Messages.Where(t => t.SourceMessage == update.EditedMessage.MessageId && t.SUserId == ueci).ToArray();
                    if (d.Length != 0)
                    {
                        Processed = true;
                        for (int i = 0; i < d.Length; i++)
                        {
                            var x = d[i].RequestId;
                            var d1 = _db.Requests.FirstOrDefault(t => t.Id == x);

                            //کاربری که پیام را ویرایش کرده خریدار است 
                            if (d1.UserId == ueci)
                            {
                                //اگر خریدار در دیتابیس  خریدار وجود دارد
                                var e = _db.Buyers.FirstOrDefault(t => t.UserId == ueci);
                                if (e != null)
                                {
                                    var firstname = e.FirstName;
                                    var lastname = e.LastName;
                                    var f = _db.Requests.Include("FieldId").FirstOrDefault(t => t.Id == x).FieldId.Name;
                                    //var fieldName = _db.Buyers.Where(t => t.UserId == ueci).Select(t => t.FieldId.Name).FirstOrDefault();
                                    EditMessage(update, d[i].DUserId, d[i].DestinationMessage, t =>
                                    {
                                        return string.Format(Farsi.SendMessageForAll, f, firstname, lastname != null ? "_" + lastname : "", t);
                                    });
                                }
                            }
                            // کاربری که پیام فرستاده فروشنده است نداریم 

                        }

                    }
                }
            }
        }
    }
}