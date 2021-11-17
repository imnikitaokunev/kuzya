using Application.Common.Interfaces;
using Application.Models.Settings;
using Telegram.Bot;

namespace Application.Bot
{
    public class KuzyaBot : IBot
    {
        private readonly BotSettings _settings;
        private readonly TelegramBotClient _client;

        public KuzyaBot(BotSettings settings)
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
