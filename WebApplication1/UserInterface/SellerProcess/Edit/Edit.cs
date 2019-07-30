using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class Edit : BaseProcess
    {
        public override void Process(Update update)
        {
            WhoAmI whoami = new WhoAmI();
            whoami.Process(update);
            var d = _db.Shops.FirstOrDefault(t => t.UserId == update.Message.Chat.Id);
            if (d == null)
                return;
            d.RegisterCallbackButtonId=SendTextMessageAsync(update.Message.Chat.Id, Farsi.WhereEdit, false, false, update.Message.MessageId, CallbackButtons.edit_keyboard()).Result.MessageId;
            _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

        }

    }
}