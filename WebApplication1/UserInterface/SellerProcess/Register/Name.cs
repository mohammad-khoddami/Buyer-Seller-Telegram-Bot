using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface
{
    public class Name : BaseProcess
    {
        public override void Process(Update update)
        {
            
            if (update.CallbackQuery != null /*&& _shopService.ExistFld(update.CallbackQuery.Message.Chat.Id)/*این شرط دوم را حتما چک کن که اضافی نباشه!*/)
            {
                //SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Data, false, false, update.Message.MessageId);
                //SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, Farsi.ShopName, false, false, 0);
                EditMessageTextAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, Farsi.ShopName, false);
            }
            else if (update.CallbackQuery == null)
            {
                    SendTextMessageAsync(update.Message.Chat.Id, Farsi.ShopName, false, false, 0);
            }
        }
    }
}