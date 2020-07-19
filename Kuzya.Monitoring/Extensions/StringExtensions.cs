using System.Text.RegularExpressions;

namespace Kuzya.Monitoring.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Parse int value from string with non digits.
        /// </summary>
        /// <param name="text">String with delimiters to be converted to int.</param>
        /// <returns>Parsed int value.</returns>
        public static int ParseInt(this string text)
        {
            text = text.Replace(" ", "");

            var pattern = new Regex(@"[^\d]");
            var replaced = pattern.Replace(text, " ");
            var substring = replaced.Substring(0, replaced.IndexOf(' '));

            return int.Parse(substring);
        }
    }
}
