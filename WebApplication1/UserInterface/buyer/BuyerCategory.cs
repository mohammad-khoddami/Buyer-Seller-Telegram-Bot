using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.buyer
{
    public class BuyerCategory : BaseProcess
    {
        public override void Process(Update update)
        {
            if (update.CallbackQuery != null)
            {
                var ucmci = update.CallbackQuery.Message.Chat.Id;
                var ucd = update.CallbackQuery.Data;
                var ucmm = update.CallbackQuery.Message.MessageId;

                var d = _db.Buyers.FirstOrDefault(t => t.UserId == ucmci);
                var c = _db.Cities.FirstOrDefault(t => t.Name == ucd);
                var category = _db.BaseCategories.ToArray();

                if (d == null || category == null)
                    return;

                d.City = c;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCategory, false, CallbackButtons.category_keyboard(category));
            }


            else if (update.CallbackQuery == null)
            {
                var umci = update.Message.Chat.Id;
                var umm = update.Message.MessageId;

                var d = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
                var category = _db.BaseCategories.ToArray();

                if (d == null || category == null)
                    return;

                //EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCategory, false, CallbackButtons.category_keyboard(category));
                d.MessageId=SendTextMessageAsync(umci, Farsi.SelectCategory, false, false,umm, CallbackButtons.category_keyboard(category)).Result.MessageId;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

            }
        }
    }
}