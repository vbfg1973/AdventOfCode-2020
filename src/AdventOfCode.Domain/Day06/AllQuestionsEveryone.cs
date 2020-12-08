using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day06
{
    public class AllQuestionsEveryone
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
            var individuals = SplitGroupIntoIndividuals(s).ToList();
            var individualCount = individuals.Count();

            var dict = new Dictionary<char, int>();
            foreach (var individual in individuals)
            foreach (var c in individual)
                if (dict.ContainsKey(c))
                    dict[c]++;

                else
                    dict[c] = 1;

            return dict.Values.Count(x => x == individualCount);
        }

        public IEnumerable<string> SplitGroupIntoIndividuals(string s)
        {
            s = StringUtils.StripAllWhiteSpaceExceptNewlines(s);

            return s.Split('\n');
        }
    }
}