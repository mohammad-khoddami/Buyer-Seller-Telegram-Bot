using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.buyer
{
    public class EnterProvinceProcess : BaseProcess
    {
        int count = 0, countline = 0;

        public override void Process(Update update)
        {

            var province = _db.Provinces.ToArray();

            if (province == null)
                return;

            SendTextMessageAsync(update.Message.Chat.Id,
                "تو کدوم استان میخوای دنبال محصولت بگردی ؟",false, false, update.Message.MessageId, keyboard(province));

        }
        public Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup keyboard(Services.ProvinceModel[] province)
        {
            var ikb = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup();
            ikb.InlineKeyboard = new InlineKeyboardButton[(province.Length / 2) + province.Length % 2][];
            while (countline < province.Length / 2)
            {
                ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                {
                        new InlineKeyboardCallbackButton(province[count].Key,province[count].Value),
                        new InlineKeyboardCallbackButton(province[count + 1].Key,province[count+1].Value)
                };
                count += 2;
                countline++;
            }
            ikb.InlineKeyboard[province.Length / 2] = new InlineKeyboardButton[]
                        {
                    new InlineKeyboardCallbackButton(province[count].Key,province[count].Value)
                        };

            return ikb;
        }

    }
}
