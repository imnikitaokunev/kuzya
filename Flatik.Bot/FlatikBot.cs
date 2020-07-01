using System;
using Telegram.Bot;

namespace Flatik.Bot
{
    public class FlatikBot : IBot
    {
        private readonly BotSettings _settings;
        private readonly TelegramBotClient _client;

        public FlatikBot(BotSettings settings)
        {
            CheckSettings(settings);

            _settings = settings;
            _client = new TelegramBotClient(settings.Token);
        }

        public async void SendMessage(string message)
        {
            var chatId = _settings.ChatId;
            await _client.SendTextMessageAsync(chatId, message, disableWebPagePreview: true);
        }

        private void CheckSettings(BotSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Token))
            {
                throw new ArgumentException("Must be not null or empty.", nameof(settings.Token));
            }
        }
    }
}
