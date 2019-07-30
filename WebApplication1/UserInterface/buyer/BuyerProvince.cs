using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.buyer
{
    public class BuyerProvince : BaseProcess
    {
        public override void Process(Update update)
        {
                var umci = update.Message.Chat.Id;
                var province = _db.Provinces.ToArray();
                var d = _db.Buyers.FirstOrDefault(t => t.UserId == umci);
                if (d == null || province == null)
                    return;
                d.MessageId = SendTextMessageAsync(umci, Farsi.SelectProvince, false, false, 0, CallbackButtons.province_keyboard(province)).Result.MessageId;
                _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            
         
        }
    }
}