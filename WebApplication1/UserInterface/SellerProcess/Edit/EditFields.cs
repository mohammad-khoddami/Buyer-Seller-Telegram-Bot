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
    public class EditFields : BaseProcess
    {
        public override void Process(Update update)
        {
            EditMessageTextAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, Farsi.AddOrDeleteFields, false, CallbackButtons.delete_or_add_keyboard());
        }

        
    }
}