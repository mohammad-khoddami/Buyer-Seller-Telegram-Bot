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
    public class BuyerField : BaseProcess
    {

        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucd = update.CallbackQuery.Data;
            var ucmm = update.CallbackQuery.Message.MessageId;

            CategoriesService categoryservice = new CategoriesService();
            var d = _db.BaseCategories.FirstOrDefault(t => t.Name == ucd);
            if (d == null)
                return;

            //if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 4)
            //{
            //    SendTextMessageAsync(ucmci, "پس تو که میخواستی نام فروشگاهتو تغییر بدی !", false, false, ucmm);
            //    CloseEditProcess closeEditProvince = new CloseEditProcess();
            //    closeEditProvince.Process(update);
            //}
            //else
            //{
            //??//
            var fields = categoryservice.MinorCategories(d.Id);
            //??//
            EditMessageTextAsync(ucmci, ucmm, Farsi.SubCategory, false, CallbackButtons.fields_keyboard(fields));
           
        }
    }
}