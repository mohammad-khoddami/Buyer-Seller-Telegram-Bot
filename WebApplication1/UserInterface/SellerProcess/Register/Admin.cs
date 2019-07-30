using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;

namespace WebApplication1.UserInterface.salesman
{
    public class Admin : BaseProcess
    {
        public override void Process(Update update)
        {
            var umt = update.Message.Text;
            var umm = update.Message.MessageId;
            if (umt == Password + "whydelete")
            {
                var d1 = _db.DeleteUsers.Where(t => t.WhyDlt == 1).Count();
                var d2 = _db.DeleteUsers.Where(t => t.WhyDlt == 2).Count();
                var d3 = _db.DeleteUsers.Where(t => t.WhyDlt == 3).Count();
                SendTextMessageAsync(Admin, string.Format(Farsi.AdminWhyDelete, d1, d2, d3), false, false, umm);
            }
            if (umt == Password + "sellerlength")
            {
                var d = _db.Shops.Count();
                SendTextMessageAsync(Admin, d.ToString(), false, false,umm);
            }
            if (umt == Password + "buyerlength")
            {
                var d = _db.Buyers.Count();
                SendTextMessageAsync(Admin, d.ToString(), false, false, umm);
            }
            if (umt == Password + "requestlength")
            {
                var d = _db.Requests.Count();
                SendTextMessageAsync(Admin, d.ToString(), false, false, umm);
            }
            if (umt == Password + "messagelength")
            {
                var d = _db.Messages.Count();
                SendTextMessageAsync(Admin, d.ToString(), false, false, umm);
            }
        }
    }
}