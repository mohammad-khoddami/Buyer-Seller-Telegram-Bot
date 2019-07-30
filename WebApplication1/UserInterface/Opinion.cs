using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface
{
    public class Opinion : BaseProcess
    {
        public override void Process(Update update)
        {
    
            //var editshop = _db.Shops.FirstOrDefault(t => t.UserId == update.Message.Chat.Id);
            //if (editshop != null)
            //{
            //    if (editshop.EditMode != -1 && editshop.EditMode != 0)
            //    {
            //        CloseEdits closeedit = new CloseEdits();
            //        closeedit.Process(update);
            //    }
            //}
            if(update.Message.Text==Farsi.SendOpinion)
                SendTextMessageAsync(update.Message.Chat.Id, Farsi.Opinion, false, false, 0);
            else
            {
                SendTextMessageAsync(Admin, string.Format(Farsi.SendOpinionToAdmin,update.Message.From.Username, update.Message.Text), false, false, 0);
            }
        }
    }
}