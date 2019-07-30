using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;

namespace WebApplication1.UserInterface
{
    public class WhoAmI : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;
            var umt = update.Message.Text;

            if (umt == Farsi.SalesMan || umt==Farsi.EditShopProfile || umt==Farsi.DeleteShopProfile||
                umt == Farsi.ShopDetails|| umt == Farsi.ShopFields)
            {
                if (_db.WhoAmIs.Any(t => t.UserId == umci))
                {
                    var d=_db.WhoAmIs.FirstOrDefault(t => t.UserId == umci);
                   d.whoAmI = 2;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                }
                else
                    _db.WhoAmIs.Add(new Models.WhoAmI
                    {
                        UserId = umci,
                        whoAmI = 2,
                    });
                _db.SaveChanges();
            }
            else if (umt == Farsi.Buyer || umt==Farsi.BuyerNewRequest)
            {
                if (_db.WhoAmIs.Any(t => t.UserId == umci))
                {
                    var d=_db.WhoAmIs.FirstOrDefault(t => t.UserId == umci);
                    d.whoAmI = 1;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                }
                else
                    _db.WhoAmIs.Add(new Models.WhoAmI
                    {
                        UserId = umci,
                        whoAmI = 1,
                    });
                _db.SaveChanges();
            }
          
            
        }
    }
}