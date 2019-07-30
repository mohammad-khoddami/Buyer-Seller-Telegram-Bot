using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman
{
    public class DbSaveFields : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;
            var ucd = update.CallbackQuery.Data;
            var ucmt = update.CallbackQuery.Message.Text;

            var findfld = _db.MinorCategories.FirstOrDefault(t => t.Name == ucd);
            if (findfld == null)
                return;

            if (_db.Fields.Any(f => f.UserId == ucmci && f.FieldId == findfld.Id))
                SendTextMessageAsync(ucmci,string.Format(Farsi.ExistField, ucd), false, false,0);

            else if (_db.Shops.FirstOrDefault(t => t.UserId == update.CallbackQuery.Message.Chat.Id).EditMode == 4)
                _db.Fields.Where(t => t.UserId == update.CallbackQuery.Message.Chat.Id && t.FieldId == -1).FirstOrDefault();

            else
            {
                _db.Fields.Add(new Models.Field { UserId = ucmci, FieldId = findfld.Id });
                _db.SaveChanges();
                SendTextMessageAsync(ucmci,string.Format(Farsi.SaveeField,update.CallbackQuery.Data), false, false, 0);

            }
        }
    }
}