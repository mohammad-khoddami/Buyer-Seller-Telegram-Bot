using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.UserInterface.salesman;

namespace WebApplication1.UserInterface.SellerProcess.Register
{
    public class CallbackInComplete : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucd = update.CallbackQuery.Data;
            var ucmt = update.CallbackQuery.Message.Text;

            
            if (ucmt == Farsi.SelectProvince)// && _db.Provinces.Any(t => t.Key == update.CallbackQuery.Data))
            {
                City city = new City();
                city.Process(update);
            }

            
            else if ((ucmt == Farsi.SelectCity)//&& _db.Cities.Any(t => t.Name == update.CallbackQuery.Data))
                || (ucd == Farsi.BackButton))
            {
                Category category = new Category();
                category.Process(update);
            }

            
            else if (ucmt == Farsi.SelectCategory)
            {
                Fields field = new Fields();
                field.Process(update);
            }

            else if (ucmt == Farsi.SubCategory && ucd != Farsi.BackButton)
            {
                DbSaveFields savefield = new DbSaveFields();
                savefield.Process(update);
            }
            
        }
    }
}