using System.Text.RegularExpressions;

namespace GlassTest.Helpers
{
    public class SqlHelper
    {
        //public static string SplitQueryByKeywords(string query)
        //{
        //    var keywords = query.Split(" ");

        //    return string.Join(" OR ", keywords.Select(k => $"\"{k}\""));
        //}
        public static string GetLikeStatement(string columnName, string query)
        {
            var keywords = query.Split(" ");

            keywords = keywords.Select(k => $"{columnName} LIKE  \'%{k}%\'").ToArray();
            return string.Join(" OR ", keywords);
        }

       
    }
}
