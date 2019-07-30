using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;

namespace WebApplication1.UserInterface.salesman
{
    public class CompleteSellerRegister : BaseProcess
    {
        public override void Process(Update update)
        {
            SendTextMessageAsync(update.Message.Chat.Id,Farsi.Help, false, false, update.Message.MessageId);
          }
    }
}