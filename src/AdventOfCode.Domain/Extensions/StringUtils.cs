using System.Text.RegularExpressions;

namespace AdventOfCode.Domain
{
    public static class StringUtils
    {
        public static string StripAllWhiteSpace(string s)
        {
            s = Regex.Replace(s, "\\s+", "");

            return s;
        }

        public static string StripAllWhiteSpaceExceptNewlines(string s)
        {
            s = Regex.Replace(s, "[^\\S+\\r\\n]", "");

            return s;
        }
    }
}