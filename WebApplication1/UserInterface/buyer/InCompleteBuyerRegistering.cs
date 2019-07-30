using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;

namespace WebApplication1.UserInterface.buyer
{
    public class InCompleteBuyerRegistering : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;

            if (_db.Buyers.Where(t => t.UserId == umci && t.Province != null).Any())
            {
                if(_db.Buyers.Where(t=>t.UserId == umci && t.City != null).Any())
                {
                    //if(_db.Buyers.Where(t=>t.UserId==umci && t.SendForAll == 1).Any())
                    //{
                    //    BuyerCategory buyercategory = new BuyerCategory();
                    //    buyercategory.Process(update);

                    //    //SendForAll sendforall = new SendForAll();
                    //    //sendforall.Process(update);
                    //}
                    //else
                    //{
                        BuyerCategory buyercategory = new BuyerCategory();
                        buyercategory.Process(update);
                 //   }
                }
                else
                {
                    BuyerCity buyercity = new BuyerCity();
                    buyercity.Process(update);
                }
            }
            else
            {
                BuyerProvince buyerprovince = new BuyerProvince();
                buyerprovince.Process(update); 
            }
        }
    }
}