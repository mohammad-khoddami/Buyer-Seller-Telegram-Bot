using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;

namespace WebApplication1.Services
{
    public class CityValid
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public bool cityChecker(Update update)
        {
            var d = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == update.CallbackQuery.Message.Chat.Id).Province;
            var y = _db.Cities.FirstOrDefault(t => t.Name == update.CallbackQuery.Data).Id;
            if (y.StartsWith(d.Value))
                return true;
            return false;
        }

    }
}