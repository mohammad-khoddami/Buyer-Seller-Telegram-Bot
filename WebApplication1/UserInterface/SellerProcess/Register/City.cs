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
    public class City : BaseProcess
    {
        public override void Process(Update update)
        {
            if (update.CallbackQuery != null)
            {
                var ucmci = update.CallbackQuery.Message.Chat.Id;
                var ucmm = update.CallbackQuery.Message.MessageId;
                var ucd = update.CallbackQuery.Data;
                var ucmt = update.CallbackQuery.Message.Text;
                CloseEdits closeedit = new CloseEdits();

                if (!_shopService.ExistPrc(ucmci))
                {
                    var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);
                    var p = _db.Provinces.FirstOrDefault(t => t.Key == ucd);
                    if (d == null || p == null)
                        return;
                    d.Province = p;
                    _db.SaveChanges();
                    //SendTextMessageAsync(ucmci, ucd, false, false, ucmm);
                    var prc = p.Value;
                    var cty = _db.Cities.Where(t => t.Id.StartsWith(prc)).ToArray();
                    if (cty == null)
                        return;
                    EditMessageTextAsync(ucmci, ucmm, Farsi.SelectCity, false, CallbackButtons.city_keyboard(cty));
                }


                else if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 1)
                {
                    var d = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == ucmci);
                    var p = _db.Provinces.FirstOrDefault(t => t.Key == ucd);

                    if (d == null || p == null)
                        return;

                    var s = d.Province.Key;

                    if (s == ucd)
                    {
                        EditMessageTextAsync(ucmci, ucmm, string.Format(Farsi.DuplicateSelection, s), false);
                        closeedit.Process(update);
                        return;
                    }

                    d.Province = p;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    //should be change the city=>
                    //d.EditMode = 2;
                    //var cty = _db.Cities.Where(t => t.Id.StartsWith(p.Value)).ToArray();
                    closeedit.Process(update);
                    EditMessageTextAsync(ucmci, ucmm, string.Format(Farsi.ShouldBeEditCity, s, p.Key), false);
                    //SendTextMessageAsync(ucmci, string.Format(Farsi.ShouldBeEditCity, s, p.Key), false, false, ucmm);
                    //EditMessageTextAsync(ucmci, ucmm, string.Format(Farsi.SelectCity, s, p.Key), false, CallbackButtons.city_keyboard(cty));
                }


                /*
                else if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 2)
                {
                    var d = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == ucmci);

                    if (d == null)
                        return;

                    var prc = d.Province.Value;
                    var cty = _db.Cities.Where(t => t.Id.StartsWith(prc)).ToArray();

                    if (cty == null)
                        return;

                    SendTextMessageAsync(ucmci, "شهرت را انتخاب کن", false, false, 0, CallbackButtons.city_keyboard(cty));
                }
                */

                /*  else if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 3)
                  {
                      CloseEditProcess closeEditProvince = new CloseEditProcess();
                      closeEditProvince.Process(update);
                  }*/

                //else if (_db.Shops.FirstOrDefault(t => t.UserId == ucmci).EditMode == 4)
                //{
                //    SendTextMessageAsync(ucmci, "پس تو که میخواستی نام فروشگاهتو تغییر بدی !", false, false, ucmm);
                //    CloseEditProcess closeEditProvince = new CloseEditProcess();
                //    closeEditProvince.Process(update);
                //}
                /*
                else
                {
                    var province = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == ucmci).Province;
                    SendTextMessageAsync(ucmci, "شما قبلا استان " + province.Key + " را انتخاب کرده اید", false, false, 0);
                }
                   */
            }



            else if (_shopService.ExistPrc(update.Message.Chat.Id))
            {
                var umci = update.Message.Chat.Id;
                var umm = update.Message.MessageId;
                var d = _db.Shops.FirstOrDefault(t => t.UserId == umci);
                /*
                if (_db.Shops.FirstOrDefault(t => t.UserId == update.Message.Chat.Id).EditMode == 1)
                    SendTextMessageAsync(update.Message.Chat.Id, "استانت را از یکی از استان های بالا انتخاب کن", false, false, update.Message.MessageId);


                else
                {*/
                var province = _db.Shops.Include("Province").FirstOrDefault(t => t.UserId == umci).Province;

                if (province == null)
                    return;

                var prc = province.Value;
                var cty = _db.Cities.Where(t => t.Id.StartsWith(prc)).ToArray();
                //SendTextMessageAsync(umci, province.Key.ToString(), false, false, umm);

                if (cty == null)
                    return;

                //      prc = prc + ".";
                //DeleteMessageAsync(umci, d.RegisterCallbackButtonId);        
                d.RegisterCallbackButtonId=SendTextMessageAsync(umci, Farsi.SelectCity, false, false, 0, CallbackButtons.city_keyboard(cty)).Result.MessageId;
                _db.SaveChanges();
            }
        }
    }

}
