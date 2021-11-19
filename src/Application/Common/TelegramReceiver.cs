using Application.Common.Interfaces;
using Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Application.Common;

public class TelegramReceiver
{
    private readonly IChatRepository _chatRepository;
    private readonly ITelegramBotClient _client;

    public bool IsRunning { get; private set; }

    public TelegramReceiver(ITelegramBotClient client, IChatRepository chatRepository)
    {
        _client = client;
        _chatRepository = chatRepository;
        _client.OnMessage += async (sender, e) => await ClientOnMessageAsync(sender, e);
    }

    public void Start()
    {
        if (IsRunning)
        {
            return;
        }

        IsRunning = true;
        _client.StartReceiving();
    }

    public void Stop()
    {
        if (!IsRunning)
        {
            return;
        }

        IsRunning = false;
        _client.StopReceiving();
    }

    private async Task ClientOnMessageAsync(object? sender, MessageEventArgs e)
    {
        // Todo: Add commands
        if (e.Message.Text.Contains("/start"))
        {
            var chat = await _chatRepository.GetByIdAsync(e.Message.Chat.Id);
            if (chat == null)
            {
                var entity = new Chat
                {
                    Id = e.Message.Chat.Id,
                    IsActive = true
                };
                await _chatRepository.AddAsync(entity);
            }
            else if (!chat.IsActive)
            {
                chat.IsActive = true;
                await _chatRepository.UpdateAsync(chat);
            }
        }
        if (e.Message.Text.Contains("/stop"))
        {
            var chat = await _chatRepository.GetByIdAsync(e.Message.Chat.Id);
            if (chat != null)
            {
                chat.IsActive = false;
                await _chatRepository.UpdateAsync(chat);
            }
        }
    }
}
