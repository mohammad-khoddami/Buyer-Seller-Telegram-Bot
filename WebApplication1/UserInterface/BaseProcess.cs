using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using WebApplication1.Message;
using WebApplication1.Services;
using Telegram.Bot.Types.InlineKeyboardButtons;
using System.Threading.Tasks;

namespace WebApplication1.UserInterface
{
    public abstract class BaseProcess : UpdateProcessor
    {
        protected Telegram.Bot.TelegramBotClient api;
        protected ApplicationDbContext _db;
        protected ShopService _shopService;
        public long Admin { get; set; }
        public string Password { get; set; }
        public BaseProcess()
        {
            //api = new Telegram.Bot.TelegramBotClient("322077479:AAGlGj4KLvs56wCfsrzMFm84aqqdES0kAus");
            api = new Telegram.Bot.TelegramBotClient("453842579:AAGj2xLR0z75W3i1F1ZRaybwMKZhxTXUv2M");
            _db = new ApplicationDbContext();
            _shopService = new ShopService();
            Admin = 54079994;
            Password = "4238";
        }
        public Task<Telegram.Bot.Types.Message> SendMessage(long to, Update update, Func<string, string> userTitleFormatter, bool disableWebPagePreview, bool disableNotification, int replyToMessageId, Telegram.Bot.Types.ReplyMarkups.IReplyMarkup replyMarkup = null)
        {
            if (update.Message.Text != null)
            {
                return api.SendTextMessageAsync(to, userTitleFormatter(update.Message.Text), Telegram.Bot.Types.Enums.ParseMode.Default, disableWebPagePreview, disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Photo?.Length > 0)
            {
                return api.SendPhotoAsync(to, new FileToSend(update.Message.Photo.First().FileId), userTitleFormatter(update.Message.Caption), disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Audio != null)
            {
                return api.SendAudioAsync(to, new FileToSend(update.Message.Audio.FileId), userTitleFormatter(update.Message.Caption), update.Message.Audio.Duration, update.Message.Audio.Performer, update.Message.Audio.Title, disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Document != null)
            {
                return api.SendDocumentAsync(to, new FileToSend(update.Message.Document.FileId), userTitleFormatter(update.Message.Caption), disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Video != null)
            {
                return api.SendVideoAsync(to, new FileToSend(update.Message.Video.FileId), update.Message.Video.Duration, update.Message.Video.Width, update.Message.Video.Height, userTitleFormatter(update.Message.Caption), disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Voice != null)
            {
                return api.SendVoiceAsync(to, new FileToSend(update.Message.Voice.FileId), userTitleFormatter(update.Message.Caption), update.Message.Voice.Duration, disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Sticker != null)
            {
                return api.SendStickerAsync(to, new FileToSend(update.Message.Sticker.FileId), disableNotification, replyToMessageId, replyMarkup);
            }
            if(update.Message.Contact != null)
            {
                return api.SendContactAsync(to, update.Message.Contact.PhoneNumber, update.Message.Contact.FirstName, update.Message.Contact.LastName,disableNotification,replyToMessageId,replyMarkup);
            }
            if(update.Message.VideoNote != null)
            {
                return api.SendVideoNoteAsync(to, new FileToSend(update.Message.VideoNote.FileId), update.Message.VideoNote.Duration, update.Message.VideoNote.Length, disableNotification, replyToMessageId, replyMarkup);
            }
            if (update.Message.Venue != null)
            {
                return api.SendVenueAsync(to, update.Message.Venue.Location.Latitude, update.Message.Venue.Location.Longitude, update.Message.Venue.Title, update.Message.Venue.Address, update.Message.Venue.FoursquareId, disableNotification, replyToMessageId, replyMarkup);
            }

            if (update.Message.Location != null)
            {
                return api.SendLocationAsync(to, update.Message.Location.Latitude, update.Message.Location.Longitude, disableNotification, replyToMessageId, replyMarkup);
            }
            return null;
        }

        public Task<Telegram.Bot.Types.Message> EditMessage(Update update, long to, int messageId, Func<string, string> userTitleFormatter)
        {
            if (update.EditedMessage.Text != null)
            {
                return api.EditMessageTextAsync(to, messageId, userTitleFormatter(update.EditedMessage.Text),Telegram.Bot.Types.Enums.ParseMode.Default,false);
            }
            if (update.EditedMessage.Photo?.Length > 0 || update.EditedMessage.Audio != null || update.EditedMessage.Document != null
                || update.EditedMessage.Video != null || update.EditedMessage.Voice != null)
            {
                return api.EditMessageCaptionAsync(to, messageId, userTitleFormatter(update.EditedMessage.Caption));
            }
            return null;
        }


        public Task<Telegram.Bot.Types.Message> SendTextMessageAsync(long userId, string text, bool disableWebPagePreview, bool disableNotification, int replyToMessageId, Telegram.Bot.Types.ReplyMarkups.IReplyMarkup replyMarkup = null)
        {
            return api.SendTextMessageAsync(userId, text, Telegram.Bot.Types.Enums.ParseMode.Default, disableWebPagePreview, disableNotification, replyToMessageId, replyMarkup);
        }

        public Task<Telegram.Bot.Types.Message> EditMessageTextAsync(long userId, int messageId, string text, bool disableWebPagePreview, Telegram.Bot.Types.ReplyMarkups.IReplyMarkup replyMarkup = null)
        {
            return api.EditMessageTextAsync(userId, messageId, text, Telegram.Bot.Types.Enums.ParseMode.Default, disableWebPagePreview, replyMarkup);
        }

        public void DeleteMessageAsync(long userId, int messageId)
        {
            api.DeleteMessageAsync(userId, messageId);
        }

        public abstract void Process(Update update);
    }
}