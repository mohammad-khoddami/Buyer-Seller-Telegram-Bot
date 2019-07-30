using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class DeleteFields : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucd = update.CallbackQuery.Data;
            var ucmm = update.CallbackQuery.Message.MessageId;

            var x = _db.MinorCategories.FirstOrDefault(t => t.Name == ucd).Id;

            if (x == null)
                return;

            var find = _db.Fields.Where(t => t.UserId == ucmci && t.FieldId == x);
            if (find.FirstOrDefault() == null)
            {
                EditMessageTextAsync(ucmci, ucmm, Farsi.DontExistInYourFields, false);
                return;
            }

            else if (_db.Fields.Where(t => t.UserId == ucmci).Count() == 2 /*&& _shopService.ClosedFld(ucmci)*/)
            {
                SendTextMessageAsync(ucmci, Farsi.AbilityDeleteFields,false, false, 0);
                return;
            }


            _db.Fields.Remove(find.FirstOrDefault());
            //d.EditMode = -1;
            _db.SaveChanges();
            var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);
            var fieldsCode = _db.Fields.Where(t => t.UserId == ucmci).Select(t => t.FieldId).ToArray();
            if (fieldsCode == null)
                return;
            Decode decode = new Decode();
            var shopFields = decode.Decoding(fieldsCode);
            EditMessageTextAsync(ucmci, ucmm, Farsi.WhichOneDelete, false, CallbackButtons.show_fields_keyboard(shopFields));
            SendTextMessageAsync(ucmci,string.Format(Farsi.SuccessDeleteField, ucd), false, false, 0);
        }
    }
}
