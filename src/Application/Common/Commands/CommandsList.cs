namespace Application.Common.Commands;

public class CommandsList : List<ICommand>
{
    public ICommand this[string command] => Contains(command) ? this.First(x => x.Contains(command)) : throw new KeyNotFoundException();

    public CommandsList(ListCommand listCommand)
    {
        Add(listCommand);
    }

    public bool Contains(string text)
    {
        return this.Any(x => x.Contains(text));
    }
}
