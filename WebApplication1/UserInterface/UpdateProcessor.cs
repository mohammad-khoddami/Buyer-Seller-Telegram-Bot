using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;

namespace WebApplication1.UserInterface
{
interface UpdateProcessor
    {
        void Process(Update update);
    }
}