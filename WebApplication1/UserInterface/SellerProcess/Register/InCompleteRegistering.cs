using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;

namespace WebApplication1.UserInterface.salesman
{
    public class InCompleteRegistering : BaseProcess
    {
        public override void Process(Update update)
        {
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;

            if (_shopService.ExistPrc(umci))
            {
                if (_shopService.ExistCty(umci))
                {
                    if (_shopService.ExistFld(umci))
                    {
                        if (_shopService.ExistShpName(umci))
                        {
                            if (_shopService.ExistShpAddr(umci))
                            {
                                CompleteSellerRegister completesellerregister = new CompleteSellerRegister();
                                completesellerregister.Process(update);
                            }
                            else
                            {
                                Address address = new Address();
                                address.Process(update);
                            }
                        }
                        else
                        {
                            Name name = new Name();
                            name.Process(update);
                        }
                    }
                    else
                    {
                        Category category = new Category();
                        category.Process(update);
                    }
                }
                else
                {
                    City city = new City();
                    city.Process(update);
                }
            }
            else
            {
                Province province = new Province();
                province.Process(update);
            }
        }
    }
}