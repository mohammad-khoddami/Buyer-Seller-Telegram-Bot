using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface.salesman
{
    public class DbShowSellerDetails : BaseProcess
    {
        public override void Process(Update update)
        {
            WhoAmI whoami = new WhoAmI();
            whoami.Process(update);
            var umci = update.Message.Chat.Id;
                var umm = update.Message.MessageId;

                var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
                if (d == null)
                    return;
                var firstName = d.First_name;
                var lastName = d.Last_name;
                var province = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == umci).Province.Key;
                if (province == null)
                    return;
                var city = _db.Shops.Include("City").FirstOrDefault(t => t.UserId == umci).City.Name;
                if (city == null)
                    return;
                var fieldsCode = _db.Fields.Where(t => t.UserId == umci).Select(t => t.FieldId).ToArray();
                if (fieldsCode == null)
                    return;
                Decode decode = new Decode();
                var shopFields = decode.Decoding(fieldsCode);
                var shopName = d.Shop_name;
                var shopAddr = d.Address;
               
            SendTextMessageAsync(umci, string.Format(Farsi.ShowSalesmanDetails, firstName, lastName, shopName, province, city, shopAddr, string.Join("\n", shopFields)),false,false,umm);
            }
        }
    }
