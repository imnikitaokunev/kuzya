namespace Application.Common.Interfaces;

public interface ITelegramService
{
    Task SendAsync(long chatId, string message);
}
