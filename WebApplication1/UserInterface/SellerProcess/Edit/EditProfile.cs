using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using WebApplication1.UserInterface.salesman.Delete;

namespace WebApplication1.UserInterface.salesman.Edit
{
    public class EditProfile : BaseProcess
    {
        public override void Process(Update update)
        {
            var ucmt = update.CallbackQuery.Message.Text;
            var ucd = update.CallbackQuery.Data;
            var ucmci = update.CallbackQuery.Message.Chat.Id;
            var ucmm = update.CallbackQuery.Message.MessageId;
            var d = _db.Shops.FirstOrDefault(t => t.UserId == ucmci);


            if (ucmt == Farsi.WhereEdit)
            {
                if (ucd == Farsi.Province)
                {
                    EditProvince editprovince = new EditProvince();
                    editprovince.Process(update);          
                }

                else if (ucd == Farsi.City)
                {
                    EditCity editcity = new EditCity();
                    editcity.Process(update);
                    }

                else if (ucd == Farsi.Fields)
                {
                    EditFields deletefld = new EditFields();
                    deletefld.Process(update);
                }

                else if (ucd == Farsi.Name)
                {
                    d.EditMode = 4;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    Name name = new Name();
                    name.Process(update);
                }

                else if (ucd == Farsi.Street)
                {
                    d.EditMode = 5;
                    _db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    Address address= new Address();
                    address.Process(update);
                }
            }
            else if(ucmt == Farsi.SelectProvince)
            {
                City city = new City();
                city.Process(update);
            }

            else if (ucmt == Farsi.SelectCity)
            {
                Category category = new Category();
                category.Process(update);
            }
            else if (ucmt == Farsi.QuestionForRemove)
            {
                DeleteUser deleteuser = new DeleteUser();
                deleteuser.Process(update);
            }
            else if (ucmt == Farsi.WhichOneDelete)
            {
                DeleteFields deletefield = new DeleteFields();
                deletefield.Process(update);
            }
            else if (ucmt == Farsi.AddOrDeleteFields)
            {
                if (ucd == Farsi.DeleteFieldEdit)
                {
                    ShowFields showfld = new ShowFields();
                    showfld.Process(update);
                }
                else if (ucd == Farsi.AddFieldEdit)
                {
                    AddFields addfields= new AddFields();
                    addfields.Process(update);
                }
            }
        }
    }
}