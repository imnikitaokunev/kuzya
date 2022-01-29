namespace Application.Common.Commands;

public interface ICommand
{
    string Name { get; }
    bool Contains(string text);
    Task Execute(string text, long chatId);
}
