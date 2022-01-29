namespace Application.Common.Commands;

public abstract class Command : ICommand
{
    public abstract string Name { get; }

    public bool Contains(string text)
    {
        return text is not null && text.Trim().StartsWith(Name);
    }

    public abstract Task Execute(string text, long chatId);
}
