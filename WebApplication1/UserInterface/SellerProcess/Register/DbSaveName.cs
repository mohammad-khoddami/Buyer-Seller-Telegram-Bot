using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman
{
    public class DbSaveName : BaseProcess
    {
        public override void Process(Update update)
        {

            var umt = update.Message.Text;
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;
            CloseEdits closeedit= new CloseEdits();

            if (umt.ToCharArray().Length <= 30)
            {
                var d = _db.Shops.FirstOrDefault(t => t.UserId == update.Message.Chat.Id);

                if (d == null)
                    return;
                if (umt.StartsWith("/"))
                {
                    SendTextMessageAsync(umci, Farsi.SlashShopName, false, false, umm);
                    return;
                }
                if (d.EditMode == 4)
                {
                    var s = d.Shop_name;
                    if (s == umt)
                    {
                        SendTextMessageAsync(umci, string.Format(Farsi.DuplicateName, s), false, false, umm);
                        closeedit.Process(update);
                        return;
                    }
                    d.Shop_name = umt;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    SendTextMessageAsync(umci, string.Format(Farsi.EditShopNmae,s,umt), false, false, umm);
                    closeedit.Process(update);
                    return;
                }
                d.Shop_name = umt;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                Address address= new Address();
                address.Process(update);
            }
            else
                SendTextMessageAsync(umci, Farsi.LengthShopName, false, false, umm);

        }
    }
}