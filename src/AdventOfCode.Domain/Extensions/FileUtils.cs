using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Domain
{
    public static class FileUtils
    {
        public static IEnumerable<string> SplitFileByBlankLines(string filename)
        {
            var buffer = new List<string>();
            foreach (var line in File.ReadAllLines(filename))
            {
                var newLine = line.Trim();

                if (newLine.Length > 0)
                {
                    buffer.Add(line);
                }

                else
                {
                    yield return string.Join("\n", buffer);
                    buffer = new List<string>();
                }
            }

            if (buffer.Any()) yield return string.Join("\n", buffer);
        }
    }
}