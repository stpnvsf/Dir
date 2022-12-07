using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal static class DirectoryService
    {
        public static Dictionary<string, double> GetAverageSize(Dir dir)
        {
            var res = dir.Files.GroupBy
                (x => x.Type).ToDictionary(x => x.Key, x => ((float)(x.Sum(y => y.Size) / x.Count())) / 1000.0);

            Console.WriteLine("Average size of each type in current direcory:");

            foreach (var f in res)
            {
                Console.WriteLine($"{f.Key} - {f.Value} kb");
            }
            return res;
        }

        public static Dictionary<string, int> GetFrequencyByType(Dir dir)
        {
            var res = dir.Files.GroupBy
                (x => x.Type).ToDictionary(x => x.Key, x => (x.Count()));

            Console.WriteLine("Frequency of each type in current directory:");

            foreach (var f in res)
            {
                Console.WriteLine($"{f.Key} - {f.Value}");
            }
            return res;
        }

    }
}
