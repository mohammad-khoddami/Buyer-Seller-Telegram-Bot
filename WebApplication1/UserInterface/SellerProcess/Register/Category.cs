using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Edit;

namespace WebApplication1.UserInterface
{
    public class Category : BaseProcess
    {
        CityValid cityvalid = new CityValid();

        public override void Process(Update update)
        {
            var category = _db.BaseCategories.ToArray();
            if (update.CallbackQuery != null)
            {
                var ucmci = update.CallbackQuery.Message.Chat.Id;
                var ucmm = update.CallbackQuery.Message.MessageId;
                var ucd = update.CallbackQuery.Data;
                var ucmt = update.CallbackQuery.Message.Text;
                CloseEdits closeedit = new CloseEdits();

                if (/*_shopService.Exist(ucmci) &&*/ ucmt == Farsi.SubCategory && ucd == Farsi.BackButton)
                    EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCategory, false, CallbackButtons.category_keyboard(category));

                else if (!_shopService.ExistCty(ucmci))
                {
                    var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);
                    var c = _db.Cities.FirstOrDefault(t => t.Name == ucd);
                    if (d == null || c == null)
                        return;
                   // SendTextMessageAsync(ucmci, ucd, false, false, ucmm);
                    d.City = c;
                    _db.SaveChanges();
                    EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCategory, false, CallbackButtons.category_keyboard(category));
                }

                else if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 2)
                {
                    var d = _db.Shops.Include("City").FirstOrDefault(t => t.UserId == ucmci);
                    var c = _db.Cities.FirstOrDefault(t => t.Name == ucd);

                    if (d == null || c == null)
                        return;

                    var s = d.City.Name;

                    if (!cityvalid.cityChecker(update))
                    {
                        var sp = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == ucmci).Province.Key;
                        SendTextMessageAsync(ucmci, string.Format(Farsi.ValidCity, ucd, sp), false, false, ucmm);
                        return;
                    }

                    if (s == ucd)
                    {
                        EditMessageTextAsync(ucmci, ucmm, string.Format(Farsi.DuplicateSelection, s), false);
                        closeedit.Process(update);
                        return;
                    }

                    d.City = c;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    closeedit.Process(update);
                    EditMessageTextAsync(ucmci, ucmm, string.Format(Farsi.EditCity, s, c.Name), false);

                }

                /*
                else if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 3)
                {
                    if (_db.Fields.Any(t => t.UserId == ucmci && t.FieldId == -1))
                    {
                        var find = _db.Fields.Where(t => t.UserId == ucmci && t.FieldId == -1).FirstOrDefault();
                        _db.Fields.Remove(find);
                        _db.SaveChanges();
                        EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCategory, false, CallbackButtons.category_keyboard(category));
                        //SendTextMessageAsync(ucmci, " بعد از اتمام ورود محصولات " + "/finish" + " را بزنید ", false, false, 0);
                    }
                    else
                    {
                        SendTextMessageAsync(ucmci, "پس تو که میخواستی محصول اضافه کنی !", false, false, ucmm);
                        CloseEditProcess closeEditProvince = new CloseEditProcess();
                        closeEditProvince.Process(update);
                    }
                }
      
                else
                {
                    var cty = _db.Shops.Include("City").FirstOrDefault(t => t.UserId == ucmci).City;
                    SendTextMessageAsync(ucmci, string.Format(Farsi.SetCityWithCloseEditCity,cty.Name), false, false, 0);
                }
                */
            }


            
            else if (_shopService.ExistCty(update.Message.Chat.Id))
            {
                var umci = update.Message.Chat.Id;
                var umm = update.Message.MessageId;
                var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);

                //var city = _db.Shops.Include("City").FirstOrDefault(t => t.UserId == umci).City;
                //if (city == null)
                //    return;
                //SendTextMessageAsync(umci, city.Name, false, false, umm);
              //  DeleteMessageAsync(umci, d.RegisterCallbackButtonId);
                d.RegisterCallbackButtonId = SendTextMessageAsync(umci, Farsi.SelectCategory, false, false, 0, CallbackButtons.category_keyboard(category)).Result.MessageId;
                _db.SaveChanges();
            }
        }
    }
}