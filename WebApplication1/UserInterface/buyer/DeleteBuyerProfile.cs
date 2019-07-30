using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;

namespace WebApplication1.UserInterface.buyer
{
    public class DeleteBuyerProfile : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            WhoAmI whoami = new WhoAmI();
            whoami.Process(update);
            var d = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
            if (d == null)
                return;
            DeleteMessageAsync(umci, d.MessageId);
            _db.Buyers.Remove(d);
            _db.SaveChanges();
            _db.Buyers.Add(new Models.BuyerModel
            {
                UserId = umci,
                FirstName = update.Message.From.FirstName,
                LastName = update.Message.From.LastName,
                UserName = update.Message.From.Username,
                SendForAll = 0,
            });
            _db.SaveChanges();
            BuyerProvince buyerprovince = new BuyerProvince();
            buyerprovince.Process(update);

        }
    }
}