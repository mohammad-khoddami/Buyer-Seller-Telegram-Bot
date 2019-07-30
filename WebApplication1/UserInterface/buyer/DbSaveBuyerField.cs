using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;

namespace WebApplication1.UserInterface.buyer
{
    public class DbSaveBuyerField : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucd = update.CallbackQuery.Data;
            var ucmm = update.CallbackQuery.Message.MessageId;

            var d=_db.Buyers.FirstOrDefault(t => t.UserId == ucmci);
            var field = _db.MinorCategories.FirstOrDefault(t => t.Name == ucd);
            if (d==null || field== null)
                return;

            d.FieldId = field;
            d.SendForAll = 1;
            _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            DeleteMessageAsync(ucmci, d.MessageId);
            SendTextMessageAsync(ucmci,Farsi.SendMessage, false, false, 0);
        }
    }
}