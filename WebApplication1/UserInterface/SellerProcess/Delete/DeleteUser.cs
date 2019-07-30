using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman.Delete
{
    public class DeleteUser : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucd = update.CallbackQuery.Data;
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var d = _db.Fields.Where(t => t.UserId == ucmci);
            var findshop = _db.Shops.Where(t => t.UserId == ucmci).FirstOrDefault();
            if (d == null || findshop == null)
                return;
            if (ucd == Farsi.DontLikeThisBot)
                _db.DeleteUsers.Add(new Models.DeleteUserModels { UserId = ucmci, WhyDlt = 1 });

            else if (ucd == Farsi.DontBeUsed)
                _db.DeleteUsers.Add(new Models.DeleteUserModels { UserId = ucmci, WhyDlt = 2 });

            else if (ucd == Farsi.ClosedMyWork)
                _db.DeleteUsers.Add(new Models.DeleteUserModels { UserId = ucmci, WhyDlt = 3 });

            var n = d.Count();

            for (int i = 0; i < n; i++)
            {
                var findfield = d.FirstOrDefault();
                _db.Fields.Remove(findfield);
                _db.SaveChanges();
            }
            var x = findshop.RegisterCallbackButtonId;
            _db.Shops.Remove(findshop);
            _db.SaveChanges();
            EditMessageTextAsync(ucmci, x, Farsi.DeleteProfile, false);
            
        }
    }
}