using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class EditCity : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;
            var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);

            var dp = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == ucmci);
            if (d == null || dp==null)
                return;
            var prc = dp.Province.Value;
            var cty = _db.Cities.Where(t => t.Id.StartsWith(prc)).ToArray();
            if (cty == null)
                return;
            /*d.RegisterCallbackButtonId=*/EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCity, false, CallbackButtons.city_keyboard(cty));

            d.EditMode = 2;
            _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            
        }
    }
}