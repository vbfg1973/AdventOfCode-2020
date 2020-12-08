using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode.Domain.Day06
{
    public class AllQuestionsAnyone
    {
        public int Count(string filename)
        {
            return CountAllGroups(filename)
                .Sum();
        }

        public IEnumerable<int> CountAllGroups(string filename)
        {
            return FileUtils.SplitFileByBlankLines(filename)
                .Select(str => CountGroup(str));
        }

        public int CountGroup(string s)
        {
            s = StringUtils.StripAllWhiteSpace(s);
            var dict = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }

                else
                {
                    dict[c] = 1;
                }
            }

            return dict.Keys.Count();
        }
    }
}