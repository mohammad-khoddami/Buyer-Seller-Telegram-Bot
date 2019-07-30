using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.buyer;
using WebApplication1.UserInterface.salesman;
using WebApplication1.UserInterface.salesman.Delete;
using WebApplication1.UserInterface.salesman.Edit;
using WebApplication1.UserInterface.SellerProcess.Register;

namespace WebApplication1.UserInterface.Main
{
    public class ExistsCallback : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;
            var ucd = update.CallbackQuery.Data;
            var ucmt = update.CallbackQuery.Message.Text;
            if (_db.WhoAmIs.Any(t => t.UserId == ucmci))
            {

                
                if (_db.WhoAmIs.FirstOrDefault(t => t.UserId == ucmci).whoAmI == 2)
                {


                    if (!_shopService.SalesmanRegCpt(ucmci))
                    {
                        CallbackInComplete callbackincomplete = new CallbackInComplete();
                        callbackincomplete.Process(update);
                    }

                    else/* if (_shopService.SalesmanRegCpt(ucmci))*/
                    {
                        EditProfile editprofile = new EditProfile();
                        editprofile.Process(update);
                    }
                }
                
                else if(_db.WhoAmIs.FirstOrDefault(t => t.UserId == ucmci).whoAmI == 1)
                {
                    if (ucmt == Farsi.SelectProvince)
                    {
                        BuyerCity buyercity = new BuyerCity();
                        buyercity.Process(update);
                    }
                    else if (ucmt == Farsi.SelectCity || ucd == Farsi.BackButton)
                    {
                        BuyerCategory buyercategory = new BuyerCategory();
                        buyercategory.Process(update);
                    }
                    else if (ucmt == Farsi.SelectCategory)
                    {
                        BuyerField buyerfield = new BuyerField();
                        buyerfield.Process(update);
                    }
                    else if (ucmt == Farsi.SubCategory)
                    {
                        DbSaveBuyerField savebuyerfield = new DbSaveBuyerField();
                        savebuyerfield.Process(update);
                    }
                }
            }
        }
    }
}
