using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman
{
    public class DbSaveAddress : BaseProcess
    {
        public override void Process(Update update)
        {

            var umt = update.Message.Text;
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;
            DbShowSellerDetails showsellerDetails = new DbShowSellerDetails();
            CloseEdits closeEditProvince = new CloseEdits();


            if (umt.ToCharArray().Length <= 50)
            {
                var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);

                if (d == null)
                    return;

                if (umt.StartsWith("/"))
                {
                    SendTextMessageAsync(umci, Farsi.SlashShopAddress, false, false, umm);
                    return;
                }

                else if (d.EditMode == 5)
                {
                    var s = d.Address;
                    if (s == umt)
                    {
                        SendTextMessageAsync(umci, string.Format(Farsi.DuplicateShopAddr, umt), false, false, umm);
                       closeEditProvince.Process(update);
                        return;
                    }
                    d.Address = umt;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    closeEditProvince.Process(update);
                    SendTextMessageAsync(umci, string.Format(Farsi.EditShopAddr,s, umt), false, false, umm);
                    showsellerDetails.Process(update);
                    return;
                }

                d.Address = umt;
                d.EditMode = -1;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                showsellerDetails.Process(update);


            }
            else
                SendTextMessageAsync(umci, Farsi.LengthShopAddress, false, false, umm);

        }
    }
}