using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman
{
    public class SellerRegistering : BaseProcess
    {
        public override void Process(Update update)
        {

            var umci = update.Message.Chat.Id;

            if (_db.Buyers.Any(t => t.UserId == umci))
            {
                _db.Buyers.FirstOrDefault(t => t.UserId == umci).SendForAll = 0;
                _db.SaveChanges();
            }   

            if (_shopService.Exist(umci))
            {
                InCompleteRegistering incompleteregistering = new InCompleteRegistering();
                incompleteregistering.Process(update);
            }
            else
            {
                _db.Shops.Add(new Models.Shop
                {
                    UserId = umci,
                    First_name = update.Message.From.FirstName,
                    Last_name = update.Message.From.LastName,
                    User_name = update.Message.From.Username,
                    EditMode = 0,
                });
                _db.SaveChanges();
                Province province = new Province();
                province.Process(update);

            }
        }
    }
}
