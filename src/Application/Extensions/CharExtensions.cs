namespace Application.Extensions
{
    public static class CharExtensions
    {
        /// <summary>
        /// Parse int value from char symbol.
        /// </summary>
        /// <param name="symbol">Char symbol to be converted to int (NOT using ASCII table).</param>
        /// <returns>Parsed int value.</returns>
        public static int ToInt(this char symbol) => symbol - '0';
    }
}
