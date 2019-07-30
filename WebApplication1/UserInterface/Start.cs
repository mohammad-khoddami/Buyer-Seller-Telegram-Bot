using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface
{
    public class Start : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            
            var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
            if (d != null)
            {
                if (d.EditMode != -1 && d.EditMode != 0)
                {
                    CloseEdits closeedit = new CloseEdits();
                    closeedit.Process(update);
                }
            }
            SendTextMessageAsync(umci, Farsi.SalesManOrBuyer, false, false, update.Message.MessageId, KeyboardButtons.start_keyboard());

        }
    }
}
