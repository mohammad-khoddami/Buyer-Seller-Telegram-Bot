using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class EditProvince : BaseProcess
    {
        public override void Process(Update update)
        {
            var d = _db.Shops.FirstOrDefault(t => t.UserId == update.CallbackQuery.Message.Chat.Id);

            var province = _db.Provinces.ToArray();
            if (province == null)
                return;
            /*d.RegisterCallbackButtonId=*/
            EditMessageTextAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, Farsi.SelectProvince, false, CallbackButtons.province_keyboard(province));
            d.EditMode = 1;
            _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}