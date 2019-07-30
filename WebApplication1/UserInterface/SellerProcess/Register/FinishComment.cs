using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman
{
    public class FinishComment : BaseProcess
    {

        public override void Process(Update update)
        {

            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;
            var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
            if (d == null)
                return;

            if (d.EditMode == 3)
            {
                d.EditMode = -1;
                _db.Fields.Add(new Models.Field
                {
                    UserId = umci,
                    FieldId = -1
                });
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                Decode _deCode = new Decode();
                var fieldids = _db.Fields.Where(t => t.UserId == umci).Select(t => t.FieldId).ToArray();
                var fields = _deCode.Decoding(fieldids);
                SendTextMessageAsync(umci, string.Join("\n", fields), false, false, umm);
            }



            else
            {
                
                if (_shopService.ClosedFld(umci))
                    SendTextMessageAsync(umci, Farsi.FinishCmtBadPosition, false, false, umm);

                else
                {
                    if (!_shopService.Existmorethanonefld(umci))
                        SendTextMessageAsync(umci, Farsi.EmptyFields, false, false, umm);
                    else
                    {
                        _db.Fields.Add(new Models.Field
                        {
                            UserId = umci,
                            FieldId = -1
                        });
                        _db.SaveChanges();
                        _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();


                        Decode _deCode = new Decode();
                        var fieldids = _db.Fields.Where(t => t.UserId == umci).Select(t => t.FieldId).ToArray();
                        var fields = _deCode.Decoding(fieldids);
                        //DeleteMessageAsync(d.UserId, d.RegisterCallbackButtonId);
                        SendTextMessageAsync(umci,string.Format(Farsi.SaveFieldsReport, string.Join("\n", fields)), false, false, umm);
                        Name name = new Name();
                        name.Process(update);


                    }
                }
            }
        }
    }
}