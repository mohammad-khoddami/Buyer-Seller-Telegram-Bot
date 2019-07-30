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
    public class ShowFields : BaseProcess
    {
        public override void Process(Update update)
        {
            WhoAmI whoami = new WhoAmI();
            whoami.Process(update);
            Decode _deCode = new Decode();
            var umci = update.Message.Chat.Id;
            var umm = update.Message.MessageId;

            var fieldIds = _db.Fields.Where(t => t.UserId == umci).Select(t => t.FieldId).ToArray();

            if (fieldIds.Length == 0)
            {
                SendTextMessageAsync(umci, Farsi.DontEnterAnyField, false, false, umm);
                return;
            }
            var fields = _deCode.Decoding(fieldIds);
            SendTextMessageAsync(umci, string.Join("\n", fields), false, false, umm);
            

        }
    }
}