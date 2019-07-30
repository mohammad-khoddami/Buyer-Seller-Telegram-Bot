using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class ShowFields : BaseProcess
    {
        int countline = 0, count = 0;
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;

            //if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 3)
            //{
            //    SendTextMessageAsync(ucmci, "پس تو که میخواستی محصول اضافه کنی !", false, false, ucmm);
            //    CloseEditProcess closeEditProvince = new CloseEditProcess();
            //    closeEditProvince.Process(update);
            //}

            //if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 4)
            //{
            //    SendTextMessageAsync(ucmci, "پس تو که میخواستی نام فروشگاهتو تغییر بدی !", false, false, ucmm);
            //    CloseEditProcess closeEditProvince = new CloseEditProcess();
            //    closeEditProvince.Process(update);
            //}
            //else
            //{

            var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);
            var fieldsCode = _db.Fields.Where(t => t.UserId == ucmci).Select(t => t.FieldId).ToArray();

            if (fieldsCode == null)
                return;

            Decode decode = new Decode();
            var shopFields = decode.Decoding(fieldsCode);
            //d.EditMode = 3;
            //_db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            //_db.SaveChanges();
            EditMessageTextAsync(ucmci, ucmm, Farsi.WhichOneDelete, false, CallbackButtons.show_fields_keyboard(shopFields));
        }

        
    }
}