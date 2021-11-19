using Application.Common.Interfaces;
using Application.Models;
using MapsterMapper;
using Telegram.Bot;

namespace Application.Common;

public class ChatNotifier : IChatNotifier
{
    private readonly IChatRepository _chatRepository;
    private readonly ITelegramBotClient _client;
    private readonly IMapper _mapper;

    public ChatNotifier(IChatRepository chatRepository, ITelegramBotClient client, IMapper mapper)
    {
        _chatRepository = chatRepository;
        _client = client;
        _mapper = mapper;
    }

    public async Task NotifyAsync(IEnumerable<ApplicationApartment> apartments)
    {
        var entities = await _chatRepository.GetAsync(x => x.IsActive);
        var chats = _mapper.Map<List<ApplicationChat>>(entities);

        foreach (var apartment in apartments)
        {
            foreach (var chat in chats)
            {
                // Todo: Add message template.
                if (chat.IsLookingFor(apartment))
                {
                    await _client.SendTextMessageAsync(chat.Id, $"{apartment.Source} - {apartment.Amount} {apartment.Currency}\n{apartment.Url}", disableWebPagePreview: true);
                }
            }
        }
    }
}
