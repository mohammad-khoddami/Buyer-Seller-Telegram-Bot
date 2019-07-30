using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.buyer
{
    public class BuyerProcess : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
        
            if (_shopService.Exist(umci) && _db.Shops.FirstOrDefault(t => t.UserId == umci).EditMode != -1)
            {
                CloseEdits closeedit= new CloseEdits();
                closeedit.Process(update);
                if (_db.Buyers.Any(t=>t.UserId==umci))

                {
                    FindSalesman requestprocess = new FindSalesman();
                    requestprocess.Process(update);
                }
                else
                {
                    EnterProvinceProcess enterProvinceprocess = new EnterProvinceProcess();
                    enterProvinceprocess.Process(update);
                }
            }
            else
            {
                if (_db.Buyers.Any(t => t.UserId == umci))
                {
                    FindSalesman requestprocess = new FindSalesman();
                    requestprocess.Process(update);
                }
                else
                {
                    EnterProvinceProcess enterProvinceprocess = new EnterProvinceProcess();
                    enterProvinceprocess.Process(update);
                }
            }
        }
    }
}