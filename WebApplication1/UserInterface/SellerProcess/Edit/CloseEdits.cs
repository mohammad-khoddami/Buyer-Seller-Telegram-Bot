using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class CloseEdits : BaseProcess
    {
        public override void Process(Update update)
        {

            if (update.CallbackQuery != null)
            {
                var ucmci = update.CallbackQuery.Message.Chat.Id;
                var ucmm = update.CallbackQuery.Message.MessageId;
                var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);

                if (d.EditMode == 1)
                {
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                   
                }
                else if (d.EditMode == 2)
                {
                    var p = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == ucmci).Province;
                    var c = _db.Shops.Include("City").FirstOrDefault(t => t.UserId == ucmci).City;
                    //if (c.Id.StartsWith(p.Value))
                    //{
                        d.EditMode = -1;
                        _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();
                    //}
                    //else
                    //{
                    //    SendTextMessageAsync(ucmci, string.Format(Farsi.DontYetEditCity,c.Name,p.Key) , false, false, ucmm);
                    //    return;
                    //}
                }
                else if (d.EditMode == 3)
                {
                    _db.Fields.Add(new Models.Field
                    {
                        UserId = ucmci,
                        FieldId = -1
                    });
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    Decode _deCode = new Decode();
                    var fieldids = _db.Fields.Where(t => t.UserId == ucmci).Select(t => t.FieldId).ToArray();
                    var fields = _deCode.Decoding(fieldids);
                    SendTextMessageAsync(ucmci, string.Join("\n", fields), false, false,0);
                   // EditMessageTextAsync(ucmci, d.RegisterCallbackButtonId, string.Join("\n", fields), false);
                }
                else if (d.EditMode == 4)
                {
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else if (d.EditMode == 5)
                {
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }

            }
            else
            {
                var umci = update.Message.Chat.Id;
                var umm = update.Message.MessageId;
                var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
                if (d.EditMode == 1)
                {
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                   // DeleteMessageAsync(umci, d.RegisterCallbackButtonId);
                }
                else if (d.EditMode == 2)
                {
                    var p = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == umci).Province;
                    var c = _db.Shops.Include("City").FirstOrDefault(t => t.UserId == umci).City;
                    //if (c.Id.StartsWith(p.Value))
                    //{
                        d.EditMode = -1;
                        _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();
                       // DeleteMessageAsync(umci, d.RegisterCallbackButtonId);
                    //}
                    //else
                    //{
                    //    SendTextMessageAsync(umci, string.Format(Farsi.DontYetEditCity, c.Name, p.Key), false, false, umm);
                    //    return;
                    //}
                }
                else if (d.EditMode == 3)
                {
                    _db.Fields.Add(new Models.Field
                    {
                        UserId = umci,
                        FieldId = -1
                    });
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    //SendTextMessageAsync(umci, string.Format(Farsi.CloseEdit, Farsi.Fields), false, false, umm);
                    Decode _deCode = new Decode();
                    var fieldids = _db.Fields.Where(t => t.UserId == umci).Select(t => t.FieldId).ToArray();
                    var fields = _deCode.Decoding(fieldids);
                    SendTextMessageAsync(umci, string.Join("\n", fields), false, false, 0);
                    //EditMessageTextAsync(umci, d.RegisterCallbackButtonId, string.Join("\n", fields), false);
                }

                else if (d.EditMode == 4)
                {
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else if (d.EditMode == 5)
                {
                    d.EditMode = -1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }

            }

        }
    }
}