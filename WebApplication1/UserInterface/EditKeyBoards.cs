using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.UserInterface.buyer;
using WebApplication1.UserInterface.salesman;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface
{
    public class EditKeyBoards : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umt = update.Message.Text;
           var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
            if (d != null)
            {
                if (d.EditMode != -1 && d.EditMode != 0)
                {
                    CloseEdits closeedit = new CloseEdits();
                    closeedit.Process(update);
                }
            }

            if (umt == Farsi.Edit)
                SendTextMessageAsync(umci, Farsi.EditKeyboard, false, false, update.Message.MessageId, KeyboardButtons.edit_Keyboard());

            else if (umt == Farsi.BuyerNewRequest)
            {
                if (_db.Buyers.Any(t => t.UserId == umci))
                {
                    DeleteBuyerProfile deletebuyerprofile = new DeleteBuyerProfile();
                    deletebuyerprofile.Process(update);
                }
                else
                {
                    WhoAmI whoami = new WhoAmI();
                    whoami.Process(update);
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
            else if (umt == Farsi.ShopFields)
            {
                salesman.ShowFields showfields = new salesman.ShowFields();
                showfields.Process(update);
            }
            else if (_shopService.SalesmanRegCpt(umci))
            {
                if (umt == Farsi.EditShopProfile)
                {
                    Edit edit = new Edit();
                    edit.Process(update);
                }
                else if (umt == Farsi.DeleteShopProfile)
                {
                    RemoveQuestion deletequestion = new RemoveQuestion();
                    deletequestion.Process(update);
                }
                else if (umt == Farsi.ShopDetails)
                {
                    DbShowSellerDetails showsellerDetails = new DbShowSellerDetails();
                    showsellerDetails.Process(update);
                }
                //else if (umt == Farsi.ShopFields)
                //{
                //    salesman.ShowFields showfields = new salesman.ShowFields();
                //    showfields.Process(update);
                //}
            }
            else if (!_shopService.SalesmanRegCpt(umci) && (umt == Farsi.EditShopProfile || umt == Farsi.DeleteShopProfile ||
                umt == Farsi.ShopDetails || umt == Farsi.ShopFields))
            {
                SendTextMessageAsync(umci, Farsi.DoneAfterRegistering, false, false, update.Message.MessageId);
            }
        }
    }
}