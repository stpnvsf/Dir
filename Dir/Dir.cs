namespace Dir
{
    public class Dir
    {
        private EnumerationOptions _enumerationOptions;
        public readonly string Path = null!;
        public string Name { get; } = null!;
        public Dictionary<string, int> FrequencyByType => GetFrequencyByType();
        public Dictionary<string, double> AverageSize => GetAverageSize();
        public List<Dir> Subdirectories { get; }
        public List<File> Files { get; }
        private List<File> AllFiles { get; }

        public Dir(string path)
        {
            if (Directory.Exists(path))
            {
                AllFiles = new List<File>();
                Files = new List<File>();
                Subdirectories = new List<Dir>();

                Path = path;
                Name = new DirectoryInfo(path).Name;

                _enumerationOptions = new EnumerationOptions() { IgnoreInaccessible = true };

                GetSubdirectories();
                GetFiles();
                GetAllFiles(Path);
            }
        }

        private void GetFiles()
        {
            var files = Directory.GetFiles(Path, "*", _enumerationOptions);

            foreach (var file in files)
            {
                Files.Add(new File(file));
            }
        }

        private void GetAllFiles(string path)
        {
            var list = Directory.GetDirectories(path, "*", _enumerationOptions);

            Parallel.ForEach<string>(list, WalkTree);
        }

        private void WalkTree(string path)
        {
            var files = Directory.GetFiles(path, "*", _enumerationOptions);
            foreach (var file in files)
            {
                AllFiles.Add(new File(file));
            }
            GetAllFiles(path);
        }

        private void GetAllFiles2(string path)
        {
            var dirs = Directory.GetDirectories(path);

            foreach (var dir in dirs)
            {
                try
                {
                    var files = Directory.GetFiles(dir);
                    foreach (var file in files)
                    {
                        AllFiles.Add(new File(file));
                    }
                    GetAllFiles(dir);
                }
                catch { continue; }
            }
        }

        private void GetSubdirectories()
        {
            var subdirectories = Directory.GetDirectories(Path, "*", _enumerationOptions);

            foreach (var subdir in subdirectories)
            {
                Subdirectories.Add(new Dir(subdir));
            }

        }

        private Dictionary<string, double> GetAverageSize(bool reload = false)
        {
            if (reload)
            {
                GetAllFiles(Path);
            }

            var res = AllFiles.GroupBy(x => x.Type)
                .ToDictionary(x => x.Key, x => ((float)(x.Sum(y => y.Size) / x.Count())) / 1000.0);

            return res;
        }

        private Dictionary<string, int> GetFrequencyByType(bool reload = false)
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
