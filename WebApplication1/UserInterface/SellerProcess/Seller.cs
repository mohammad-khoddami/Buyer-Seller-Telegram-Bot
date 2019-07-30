using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman;
using WebApplication1.UserInterface.salesman.Edit;
using WebApplication1.UserInterface.salesman.Register;

namespace WebApplication1.UserInterface.SellerProcess
{
    public class Seller : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umt = update.Message.Text;
            if (umt != null)
            {
                if (_db.Shops.Any(t => t.UserId == umci))
                {
                    var editMode = _db.Shops.FirstOrDefault(t => t.UserId == umci).EditMode;
                    if (editMode == 1 || editMode == 2 )
                    {
                        CloseEdits closeedit = new CloseEdits();
                        closeedit.Process(update);
                    }
                    else if(editMode == 3)
                    {
                        CloseEdits closeedit = new CloseEdits();
                        closeedit.Process(update);
                        return;
                    }
                    else if (editMode == 4)
                    {
                        DbSaveName savename = new DbSaveName();
                        savename.Process(update);
                    }
                    else if (editMode == 5)
                    {
                        DbSaveAddress Saveaddress = new DbSaveAddress();
                        Saveaddress.Process(update);
                    }
                }
                if (_shopService.SalesmanRegCpt(umci))
                {
                    CompleteRegistering completeregistering = new CompleteRegistering();
                    completeregistering.Process(update);
                }


                else
                {
                    Registering register = new Registering();
                    register.Process(update);

                }
            }
        }
    }
}