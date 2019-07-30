using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class AddFields : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;
            var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);

            d.EditMode = 3;
            _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            var find = _db.Fields.Where(t => t.UserId == ucmci && t.FieldId == -1).FirstOrDefault();
            var category = _db.BaseCategories.ToArray();
            if (find == null || category == null)
                return;

            _db.Fields.Remove(find);
            _db.SaveChanges();
            EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCategory, false, CallbackButtons.category_keyboard(category));
            //SendTextMessageAsync(ucmci, " بعد از اتمام ورود محصولات " + "/finish" + " را بزنید ", false, false, 0);

        }
    }
}