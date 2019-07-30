using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman.Register
{
    public class Registering:BaseProcess
    {
        public override void Process(Update update)
        {
            var umt = update.Message.Text;
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;

            if (umt == Farsi.SalesMan)
            {
                SellerRegistering sellerregistering = new SellerRegistering();
                sellerregistering.Process(update);
            }
            else if (umt == Farsi.FinishCmt)
            {
                FinishComment finishcomment = new FinishComment();
                finishcomment.Process(update);
            }
            //else if (umt == Farsi.ShopFieldsCmt)
            //{
            //    ShowFields showfields = new ShowFields();
            //    showfields.Process(update);
            //}

            else if (_shopService.CheckForDbSaveShopNameAndAddr(umci))
            {
                if (!_shopService.ExistShpName(umci))
                {
                    DbSaveName savename = new DbSaveName();
                    savename.Process(update);
                }
                else if (!_shopService.ExistShpAddr(umci))
                {
                    DbSaveAddress saveaddress = new DbSaveAddress();
                    saveaddress.Process(update);
                }
            }

            //else if (_db.Shops.FirstOrDefault(t => t.UserId == umci).EditMode == 3)
            //{
            //    CloseEditProcess closeeditp = new CloseEditProcess();
            //    closeeditp.Process(update);
            //}

            else if (umt == "/edit" || umt == "/deleteaccount" || umt == "/shopdetails")
                SendTextMessageAsync(umci, Farsi.DoneAfterRegistering, false, false, umm);


        }
    }
}