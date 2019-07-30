using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;
using WebApplication1.Message;
namespace WebApplication1.Services
{
    public class KeyboardButtons
    {
        public static ReplyKeyboardMarkup start_keyboard()
        {

            var rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard = new KeyboardButton[][]
                   {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Farsi.SalesMan),
                        new KeyboardButton(Farsi.Buyer),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Farsi.Edit),
                        new KeyboardButton(Farsi.SendOpinion),
                    }
                    };
            rkm.ResizeKeyboard = true;


            return rkm;
        }
       
        public static ReplyKeyboardMarkup edit_Keyboard()
        {
            var rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard = new KeyboardButton[][]
                   {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Farsi.EditShopProfile),
                        new KeyboardButton(Farsi.DeleteShopProfile),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Farsi.ShopDetails),
                        new KeyboardButton(Farsi.ShopFields),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Farsi.BuyerNewRequest),
                        new KeyboardButton(Farsi.BackButton),
                    }

                    };
            rkm.ResizeKeyboard = true;
            return rkm;

        }
    }
}