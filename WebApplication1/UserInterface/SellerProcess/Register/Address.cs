using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface
{
    public class Address : BaseProcess
    {
        public override void Process(Update update)
        {
            
            if (update.CallbackQuery != null)
            {
               // var d = _db.Shops.FirstOrDefault(t => t.UserId == update.CallbackQuery.Message.Chat.Id);
                //DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, d.RegisterCallbackButtonId);
                EditMessageTextAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, Farsi.ShopAddress, false);
            }
            else if(update.CallbackQuery==null)
                SendTextMessageAsync(update.Message.Chat.Id, Farsi.ShopAddress, false, false, 0);
            
        }
    }
}