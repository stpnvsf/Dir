namespace Dir
{
    public class Dir
    {
        public readonly string Path = null!;
        public string Name { get; } = null!;
        public double Size { get; }

        public Dictionary<string, int> FrequencyByType => GetFrequencyByType();
        public Dictionary<string, double> AverageSize => GetAverageSize();
        public List<Dir> Subdirectories { get; }
        public List<File> Files { get; }
        private List<File> AllFiles { get; }

        public Dir(string path)
        {
            if (Directory.Exists(path))
            {
                Path = path;
                Name = new DirectoryInfo(path).Name;
                AllFiles = new List<File>();
                Files = new List<File>();
                Subdirectories = new List<Dir>();

                foreach (var file in Directory.GetFiles(path))
                {
                    Files.Add(new File(file));
                }

                GetSubdirectories(path);
                GetAllFiles(path);

                Size = AllFiles.Sum(x => x.Size) / 1000.0;
            }
        }

        private void GetAllFiles(string path)
        {
            var t = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (var file in t)
            {
                AllFiles.Add(new File(file));
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
                GetAllFiles(Path);
            }

            var res = AllFiles.GroupBy(x => x.Type)
                .ToDictionary(x => x.Key, x => ((float)(x.Sum(y => y.Size) / x.Count())) / 1000.0);

            return res;
        }

        public Dictionary<string, int> GetFrequencyByType(bool reload = false)
        {
            if (reload)
            {
                GetAllFiles(Path);
            }
            var res = AllFiles.GroupBy
                (x => x.Type).ToDictionary(x => x.Key, x => (x.Count()));

            return res;
        }
    }
}