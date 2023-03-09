using System.Text.RegularExpressions;

namespace GlassTest.Helpers
{
    public static class StringHelper
    {
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^0-9A-Za-z ,]", "", RegexOptions.Compiled);
        }
    }
}
