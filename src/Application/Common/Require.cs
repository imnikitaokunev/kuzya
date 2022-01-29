namespace Application.Common;

public static class Require
{
    public static void NotNull<T>(T argument, string argumentName) where T : class
    {
        if (argument is not null)
        {
            return;
        }

        if (string.IsNullOrEmpty(argumentName))
        {
            throw new ArgumentNullException();
        }

        throw new ArgumentNullException(argumentName);
    }
}
