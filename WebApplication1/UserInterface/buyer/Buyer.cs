using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Models;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.buyer
{
    public class Buyer : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umt = update.Message.Text;
            //ارسال ویدئو
            if (umt != null)
            {
                if (_db.Shops.Any(t => t.UserId == umci))
                {
                    var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
                    if (d.EditMode != -1 && d.EditMode != 0)
                    {
                        CloseEdits closeedit = new CloseEdits();
                        closeedit.Process(update);
                    }
                }
                if (_db.Buyers.Any(t => t.UserId == umci))
                {
                    var d = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
                    //if (umt == Farsi.NewRequestCmd)
                    //{
                    //    DeleteBuyerProfile deletebuyerprofile = new DeleteBuyerProfile();
                    //    deletebuyerprofile.Process(update);
                    //}
                    //else
                    //{
                    if (umt == Farsi.Buyer)
                    {
                        InCompleteBuyerRegistering incomplete = new InCompleteBuyerRegistering();
                        incomplete.Process(update);
                    }
                    else if (d.SendForAll == 1)
                    {
                        SendForAll sendforall = new SendForAll();
                        sendforall.Process(update);
                    }
                    //else if(umt == Farsi.Buyer)
                    //{
                    //    InCompleteBuyerRegistering incomplete = new InCompleteBuyerRegistering();
                    //    incomplete.Process(update);
                    //}
                    //    }
                }
                else
                {
                    _db.Buyers.Add(new BuyerModel
                    {
                        UserId = umci,
                        FirstName = update.Message.From.FirstName,
                        LastName = update.Message.From.LastName,
                        UserName = update.Message.From.Username,
                        SendForAll = 0,
                    });
                    _db.SaveChanges();
                    BuyerProvince buyerprovince = new BuyerProvince();
                    buyerprovince.Process(update);
                }
            }
        }
    }
}