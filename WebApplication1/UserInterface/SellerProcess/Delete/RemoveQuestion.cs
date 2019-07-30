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
    public class RemoveQuestion : BaseProcess
    {
        public override void Process(Update update)
        {
            WhoAmI whoami = new WhoAmI();
            whoami.Process(update);
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;
            var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
            //DeleteMessageAsync(umci, d.RegisterCallbackButtonId);
            d.RegisterCallbackButtonId=SendTextMessageAsync(umci,Farsi.QuestionForRemove , false, false, umm,CallbackButtons.question_for_remove_keyboard()).Result.MessageId;
            _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

        }
    }
}