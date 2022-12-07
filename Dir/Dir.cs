using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal class Dir
    {
        private string _path;
        public string Name { get; }
        public long Size { get; }

        public Dictionary<string, int> FrequencyByType => GetFrequencyByType();
        public Dictionary<string, double> AverageSize => GetAverageSize();
        public List<Dir>? Subdirectories { get; }
        public List<File>? Files { get; }

        public Dir(string path)
        {
            if (Directory.Exists(path))
            {
                _path = path;
                Name = new DirectoryInfo(_path).Name;
                Files = new List<File>();
                Subdirectories = new List<Dir>();

                GetSubdirectories(path);
                GetAllFiles(path);

            }

        }

        private void GetAllFiles(string path)
        {

            var t = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (var file in t)
            {
                Files.Add(new File(file));
            }

        }

        private void GetSubdirectories(string path)
        {

            foreach (var dir in Directory.GetDirectories(path))
            {
                Subdirectories.Add(new Dir(dir));
            }

        }

        public Dictionary<string, double> GetAverageSize(bool reload = false)
        {

            if (reload)
            {
                GetAllFiles(_path);
            }

            var res = Files.GroupBy(x => x.Type)
                .ToDictionary(x => x.Key, x => ((float)(x.Sum(y => y.Size) / x.Count())) / 1000.0);

            return res;

        }

        public Dictionary<string, int> GetFrequencyByType(bool reload = false)
        {

            if (reload)
            {
                GetAllFiles(_path);
            }
            var res = Files.GroupBy
                (x => x.Type).ToDictionary(x => x.Key, x => (x.Count()));

            return res;

        }

    }
}
