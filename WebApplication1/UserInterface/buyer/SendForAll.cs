using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;

namespace WebApplication1.UserInterface.buyer
{
    public class SendForAll : BaseProcess
    {
        int count = 0;
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;
            var umt = update.Message.Text;
            //var d = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
            var d = _db.Buyers.Where(t => t.UserId == umci);

            if (d == null)
                return;
            var y = d.Select(t => t.FieldId).FirstOrDefault();
            _db.Requests.Add(new Models.Request
            {
                UserId = umci,
                FieldId = y,
            });

            _db.SaveChanges();
           
            var k = _db.Requests.OrderByDescending(t => t.Id).FirstOrDefault(t => t.UserId == umci && t.FieldId.Id == y.Id).Id;
            var p = d.Select(t => t.Province).FirstOrDefault().Key;
            var c = d.Select(t => t.City).FirstOrDefault().Name;
            var provincecity = _db.Shops.Where(t => t.Province.Key == p && t.City.Name == c).Select(t => t.UserId).ToArray();
            
            for (int i = 0; i < provincecity.Length; i++)
            {
                var x = provincecity[i];
                if (x == umci || !_shopService.SalesmanRegCpt(x))
                    continue;

                var field = _db.Fields.FirstOrDefault(t => t.UserId == x && t.FieldId == y.Id/* d.FieldId.Id*/);
                if (field != null)
                {
                    var firstname = d.Select(t => t.FirstName).FirstOrDefault();
                    var lastname = d.Select(t => t.LastName).FirstOrDefault();
                    var messageid = SendTextMessageAsync(field.UserId, 
                        string.Format(Farsi.SendMessageForAll,y.Name,firstname,lastname!=null?"_"+lastname:"" , umt),
                        false, false, 0).Result.MessageId;
                    _db.Messages.Add(new Models.Message
                    {
                        SUserId = umci,
                        SourceMessage = update.Message.MessageId,
                        DestinationMessage = messageid,
                        RequestId = k,
                        DUserId=field.UserId
                    });
                    _db.SaveChanges();

                    count++;
                }
            }

            SendTextMessageAsync(umci,count!=0 ? string.Format(Farsi.SendForAll, count, count, y.Name, d.Select(t=>t.Province).FirstOrDefault().Key,
                d.Select(t => t.City).FirstOrDefault().Name) : Farsi.NotFoundSeller 
                , false, false, 0);
            d.FirstOrDefault().SendForAll = 0;
            _db.SaveChanges();

        }
    }
}