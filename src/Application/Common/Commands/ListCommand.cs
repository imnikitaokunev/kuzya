using System.Text;
using Application.Common.Interfaces;

namespace Application.Common.Commands;

public class ListCommand : Command, ICommand
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly ITelegramService _telegramService;

    public override string Name => "/list";

    public ListCommand(ISubscriptionRepository subscriptionRepository, ITelegramService telegramService)
    {
        _subscriptionRepository = subscriptionRepository;
        _telegramService = telegramService;
    }

    public override async Task Execute(string text, long chatId)
    {
        var subscriptions = (await _subscriptionRepository.GetActiveByChatIdAsync(chatId)).ToList();
        var sb = new StringBuilder();

        sb.AppendLine("Active subscriptions: ");
        sb.AppendLine();

        for (var i = 0; i < subscriptions.Count; ++i)
        {
            sb.AppendLine($"{i + 1}. <code>{subscriptions[i].Name}</code>");
        }

        await _telegramService.SendAsync(chatId, sb.ToString());
    }
}
