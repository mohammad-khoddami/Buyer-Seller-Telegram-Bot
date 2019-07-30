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
    public class BuyerCity : BaseProcess
    {
        public override void Process(Update update)
        {
            if (update.CallbackQuery != null)
            {
                var ucmci = update.CallbackQuery.Message.Chat.Id;
                var ucd = update.CallbackQuery.Data;
                var ucmm = update.CallbackQuery.Message.MessageId;

                var d = _db.Buyers.FirstOrDefault(t => t.UserId == ucmci);
                var p = _db.Provinces.FirstOrDefault(t => t.Key == ucd);
                if (p == null || d == null)
                    return;
                d.Province = p;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                var prc = p.Value;
                var cty = _db.Cities.Where(t => t.Id.StartsWith(prc)).ToArray();
                if (cty == null)
                    return;
                EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCity, false, CallbackButtons.city_keyboard(cty));
            }
            else if (update.CallbackQuery == null)
            {
                var umci = update.Message.Chat.Id;
                var ucmm = update.Message.MessageId;

                var d = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
                var p = _db.Buyers.Include("Province").FirstOrDefault(t => t.UserId==umci).Province;
                if (p == null || d == null)
                    return;
              
                var prc = p.Value;
                var cty = _db.Cities.Where(t => t.Id.StartsWith(prc)).ToArray();
                if (cty == null)
                    return;
                //EditMessageTextAsync(umci, ucmm, Farsi.SelectCity, false, CallbackButtons.city_keyboard(cty));
                d.MessageId=SendTextMessageAsync(umci, Farsi.SelectCity, false, false,0, CallbackButtons.city_keyboard(cty)).Result.MessageId;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

            }
        }
    }
}