using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman.Register
{
    public class CompleteRegistering : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umt = update.Message.Text;
            var umm = update.Message.MessageId;

            
            //if (umt == Farsi.EditCmt)
            //{
            //    Edit.Edit edit = new Edit.Edit();
            //    edit.Process(update);
            //}
            //else if (umt == Farsi.DeleteAccountCmt)
            //{
            //    RemoveQuestion deletequestion = new RemoveQuestion();
            //    deletequestion.Process(update);
            //}
            //else if (umt == Farsi.ShopDetailsCmt)
            //{
            //    DbShowSellerDetails showsellerDetails = new DbShowSellerDetails();
            //    showsellerDetails.Process(update);
            //}
            //else if (umt == Farsi.ShopFieldsCmt)
            //{
            //    ShowFields showfields = new ShowFields();
            //    showfields.Process(update);
            //}


             if (umt == Farsi.SalesMan)
            {
                SendTextMessageAsync(umci, Farsi.SuccessRegistering, false, false, umm);
            }
            else if (umt == Farsi.FinishCmt)
            {
                FinishComment finishcomment = new FinishComment();
                finishcomment.Process(update);
            }
        }
    }
}