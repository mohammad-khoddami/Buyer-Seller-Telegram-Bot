using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Message;
using Telegram.Bot.Types;

namespace WebApplication1.Services
{
    public class CallbackButtons
    {
        public static InlineKeyboardMarkup province_keyboard(ProvinceModel[] province)
        {
            int count = 0, countline = 0;
            var ikb = new InlineKeyboardMarkup();
            ikb.InlineKeyboard = new InlineKeyboardButton[(province.Length / 2) + province.Length % 2][];
            while (countline < province.Length / 2)
            {
                ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                {

                        new KeyboardButton(province[count].Key),
                        new KeyboardButton(province[count + 1].Key)
                };
                count += 2;
                countline++;
            }
            ikb.InlineKeyboard[province.Length / 2] = new InlineKeyboardButton[]
                        {
                    new KeyboardButton(province[count].Key)
                        };

            return ikb;
        }

        public static InlineKeyboardMarkup city_keyboard(CityModel[] cty)
        {
            int count = 0, countline = 0;
            var ikb = new InlineKeyboardMarkup();
            if (cty.Length % 3 == 0)
            {
                ikb.InlineKeyboard = new InlineKeyboardButton[(cty.Length / 3)][];
                while (countline < cty.Length / 3)
                {
                    ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                    {
                    new KeyboardButton(cty[count].Name),
                    new KeyboardButton(cty[count + 1].Name),
                    new KeyboardButton(cty[count + 2].Name),
                    };
                    count += 3;
                    countline++;
                }
                return ikb;
            }
            ikb.InlineKeyboard = new InlineKeyboardButton[(cty.Length / 3) + 1][];
            while (countline < cty.Length / 3)
            {
                ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                {
                    new KeyboardButton(cty[count].Name),
                    new KeyboardButton(cty[count + 1].Name),
                    new KeyboardButton(cty[count + 2].Name),
                };
                count += 3;
                countline++;
            }
            if (cty.Length % 3 == 1)
            {
                ikb.InlineKeyboard[cty.Length / 3] = new InlineKeyboardButton[]
                 {
                    new KeyboardButton(cty[count].Name)
                 };
            }
            else if (cty.Length % 3 == 2)
            {
                ikb.InlineKeyboard[cty.Length / 3] = new InlineKeyboardButton[]
                 {
                    new KeyboardButton(cty[count].Name),
                    new KeyboardButton(cty[count + 1].Name),
                 };
            }
            return ikb;
        }

        public static InlineKeyboardMarkup category_keyboard(Models.BaseCategory[] category)
        {
            int count = 0, countline = 0;
            var ikb = new InlineKeyboardMarkup();
            if (category.Length % 2 == 0)
            {
                ikb.InlineKeyboard = new InlineKeyboardButton[(category.Length / 2)][];
                while (countline < category.Length / 2)
                {
                    ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                    {
                        new KeyboardButton(category[count].Name),
                        new KeyboardButton(category[count + 1].Name)
                    };
                    count += 2;
                    countline++;
                }
                return ikb;
            }
            ikb.InlineKeyboard = new InlineKeyboardButton[(category.Length / 2) + category.Length % 2][];
            while (countline < category.Length / 2)
            {
                ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                {
                        new KeyboardButton(category[count].Name),
                        new KeyboardButton(category[count + 1].Name)
                };
                count += 2;
                countline++;
            }
            ikb.InlineKeyboard[category.Length / 2] = new InlineKeyboardButton[]
            {
                new KeyboardButton(category[count].Name)
            };
            return ikb;

        }

        public static InlineKeyboardMarkup fields_keyboard(Models.MinorCategory[] category)
        {
            int count = 0, countline = 0;
            var ikb = new InlineKeyboardMarkup();
            if (category.Length % 2 == 0)
            {
                ikb.InlineKeyboard = new InlineKeyboardButton[(category.Length / 2) + 1][];
                while (countline < category.Length / 2)
                {
                    ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                    {
                        new KeyboardButton(category[count].Name),
                        new KeyboardButton(category[count+1].Name)
                    };
                    count += 2;
                    countline++;
                }
                ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                {
                    new KeyboardButton(Farsi.BackButton)
                };
            }
            else if (category.Length % 2 == 1)
            {
                ikb.InlineKeyboard = new InlineKeyboardButton[(category.Length / 2) + category.Length % 2][];
                while (countline < category.Length / 2)
                {
                    ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                    {
                        new KeyboardButton(category[count].Name),
                        new KeyboardButton(category[count+1].Name)
                    };
                    count += 2;
                    countline++;
                }
                ikb.InlineKeyboard[category.Length / 2] = new InlineKeyboardButton[]
                {
                    new KeyboardButton(category[count].Name),
                    new KeyboardButton(Farsi.BackButton)
                };
            }
            return ikb;
        }

        public static InlineKeyboardMarkup question_for_remove_keyboard()
        {
            var ikb = new InlineKeyboardMarkup();
            ikb.InlineKeyboard = new InlineKeyboardButton[3][];
            ikb.InlineKeyboard[0] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.DontLikeThisBot)
            };
            ikb.InlineKeyboard[1] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.DontBeUsed)
            };
            ikb.InlineKeyboard[2] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.ClosedMyWork)
            };
            return ikb;
        }


        public static InlineKeyboardMarkup edit_keyboard()
        {
            var ikb = new InlineKeyboardMarkup();
            ikb.InlineKeyboard = new InlineKeyboardButton[5][];
            ikb.InlineKeyboard[0] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.Province)
            };
            ikb.InlineKeyboard[1] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.City)
            };
            ikb.InlineKeyboard[2] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.Fields)
            };
            ikb.InlineKeyboard[3] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.Name)
            };
            ikb.InlineKeyboard[4] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.Street)
            };
            return ikb;
        }

        public static InlineKeyboardMarkup delete_or_add_keyboard()
        {
            var ikb = new InlineKeyboardMarkup();
            ikb.InlineKeyboard = new InlineKeyboardButton[1][];
            ikb.InlineKeyboard[0] = new InlineKeyboardButton[]
            {
                new KeyboardButton(Farsi.DeleteFieldEdit),
                new KeyboardButton(Farsi.AddFieldEdit),
            };
            return ikb;
        }

        public static InlineKeyboardMarkup show_fields_keyboard(string[] shopFields)
        {
            int count = 0, countline = 0;
            var ikb = new InlineKeyboardMarkup();
            if (shopFields.Length % 3 == 0)
            {
                ikb.InlineKeyboard = new InlineKeyboardButton[(shopFields.Length / 3)][];
                while (countline < shopFields.Length / 3)
                {
                    ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                    {
                    new KeyboardButton(shopFields[count]),
                    new KeyboardButton(shopFields[count + 1]),
                    new KeyboardButton(shopFields[count + 2]),
                    };
                    count += 3;
                    countline++;
                }
                return ikb;
            }
            ikb.InlineKeyboard = new InlineKeyboardButton[(shopFields.Length / 3) + 1][];
            while (countline < shopFields.Length / 3)
            {
                ikb.InlineKeyboard[countline] = new InlineKeyboardButton[]
                {
                    new KeyboardButton(shopFields[count]),
                    new KeyboardButton(shopFields[count + 1]),
                    new KeyboardButton(shopFields[count + 2]),
                };
                count += 3;
                countline++;
            }
            if (shopFields.Length % 3 == 1)
            {
                ikb.InlineKeyboard[shopFields.Length / 3] = new InlineKeyboardButton[]
                 {
                    new KeyboardButton(shopFields[count])
                 };
            }
            else if (shopFields.Length % 3 == 2)
            {
                ikb.InlineKeyboard[shopFields.Length / 3] = new InlineKeyboardButton[]
                 {
                    new KeyboardButton(shopFields[count]),
                    new KeyboardButton(shopFields[count + 1]),
                 };
            }
            return ikb;
        }
    }
}