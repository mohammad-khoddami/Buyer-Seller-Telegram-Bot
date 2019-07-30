using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.buyer;
using WebApplication1.UserInterface.salesman;
using WebApplication1.UserInterface.salesman.Edit;
using WebApplication1.UserInterface.salesman.Register;
using WebApplication1.UserInterface.SellerProcess;

namespace WebApplication1.UserInterface.Main
{
    public class NullCallback : BaseProcess
    {
        public override void Process(Update update)
        {
            if (update.Message != null)
            {
                var umci = update.Message.Chat.Id;
                var umt = update.Message.Text;
                if (_db.Shops.Any(t => t.UserId == umci))
                    DeleteMessageAsync(umci, _db.Shops.FirstOrDefault(t => t.UserId == umci).RegisterCallbackButtonId);
                if (_db.Buyers.Any(t => t.UserId == umci))
                    DeleteMessageAsync(umci, _db.Buyers.FirstOrDefault(t => t.UserId == umci).MessageId);

                if (umt == Farsi.StartCmt || umt==Farsi.BackButton)
                {
                    Start start = new Start();
                    start.Process(update);
                }
               else if (umt == Farsi.Edit || umt==Farsi.EditShopProfile || umt==Farsi.DeleteShopProfile||
                    umt==Farsi.ShopDetails||umt==Farsi.ShopFields || umt==Farsi.BuyerNewRequest)
                {
                    EditKeyBoards editkeyboard = new EditKeyBoards();
                    editkeyboard.Process(update);
                }
                else if (umt == Farsi.SendOpinion || (umt!=null && umt.StartsWith(Farsi.OpinionFormat)))
                {
                    Opinion opinion = new Opinion();
                    opinion.Process(update);
                }

                else
                {
                    if ((umt == Farsi.SalesMan || umt == Farsi.Buyer))
                    {
                        WhoAmI whoami = new WhoAmI();
                        whoami.Process(update);
                    }

                    Communication communication = null;
                    if (update.Message.ReplyToMessage != null)
                    {
                        communication = new Communication();
                        communication.Process(update);
                    }
                    
                    if ((communication == null || !communication.Processed) && _db.WhoAmIs.Any(t => t.UserId == umci))
                    {
                        var d = _db.WhoAmIs.FirstOrDefault(t => t.UserId == umci);
                        if (d.whoAmI == 2)
                        {
                            Seller seller = new Seller();
                            seller.Process(update);
                        }
                        else if (d.whoAmI == 1)
                        {
                            Buyer buyer = new Buyer();
                            buyer.Process(update);
                        }
                    }
        
                    if (umci == Admin)
                    {
                        Admin admin = new Admin();
                        admin.Process(update);
                    }
        
                }
            }
            else if(update.EditedMessage != null)
            {
                    Communication communication = new Communication();
                    communication.Process(update);
              
            }
        }
    }
}
