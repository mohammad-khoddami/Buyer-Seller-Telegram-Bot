using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface
{
    public class Fields : BaseProcess
    {
        CategoriesService categoryservice = new CategoriesService();

        public override void Process(Update update)
        {
            var ucd = update.CallbackQuery.Data;
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;

            var a = _db.BaseCategories.FirstOrDefault(t => t.Name == ucd).Id;

            if (a == null)
                return;

            var category = categoryservice.MinorCategories(a);
      
            EditMessageTextAsync(ucmci, ucmm, Farsi.SubCategory, false, CallbackButtons.fields_keyboard(category));

        }
    }
}