using Application.Common.Commands;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Application.Workers;

public class TelegramWorker : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<TelegramWorker> _logger;
    private readonly QueuedUpdateReceiver _updateReceiver;
    private readonly CommandsList _commandsList;

    public TelegramWorker(ITelegramBotClient botClient, ILogger<TelegramWorker> logger, CommandsList commandsList)
    {
        _botClient = botClient;
        _logger = logger;
        _updateReceiver = new QueuedUpdateReceiver(botClient);
        _commandsList = commandsList;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await foreach (var update in _updateReceiver.WithCancellation(stoppingToken))
            {
                if (update.Message is Message message && !string.IsNullOrEmpty(message.Text))
                {
                    //Console.WriteLine(message.Text);

                    if (!_commandsList.Contains(message.Text))
                    {
                        await _botClient.SendTextMessageAsync(message.Chat.Id, "Could not recognize you :(", cancellationToken: stoppingToken);
                        continue;
                    }

                    await _commandsList[message.Text].Execute(message.Text, message.Chat.Id);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }
}
