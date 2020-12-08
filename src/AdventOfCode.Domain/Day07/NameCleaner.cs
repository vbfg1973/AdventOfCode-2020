namespace AdventOfCode.Domain.Day07
{
    public static class NameCleaner
    {
        public static string CleanBagName(this string str)
        {
            str = str.Trim();
            if (str[str.Length - 1] == '.') str = str.Remove(str.LastIndexOf('.'));
            if (str[str.Length - 1] == 's') str = str.Remove(str.LastIndexOf('s'));

            return str;
        }
    }
}