using System.Diagnostics;

namespace Dir
{
    public class Dir
    {
        private EnumerationOptions _enumerationOptions;
        public readonly string Path = null!;
        public string Name { get; } = null!;
        public double Size => SetDirectorySize();

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

                GetSubdirectories(path);
                GetFiles(path);
                GetAllFiles(path);
            }
        }

        private void GetFiles(string path)
        {
            var files = Directory.GetFiles(path, "*", _enumerationOptions);

            foreach (var file in files)
            {
                Files.Add(new File(file));
            }
        }
        //parallel for, concurrency dictionary
        //var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        private void GetAllFiles(string path)
        {
            var files = Directory.GetFiles(path, "*", _enumerationOptions);

            foreach (var file in files)
            {
                AllFiles.Add(new File(file));
            }

        }

        private void GetSubdirectories(string path)
        {
            var subdirectories = Directory.GetDirectories(path, "*", _enumerationOptions);

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
        private double SetDirectorySize(bool reload = false)
        {
            var res = AllFiles.Sum(x => x.Size) / 1000.0;
            return res;
        }

        public List<string> GetAllAncestors()
        {
            List<string> ancestors = new List<string>() { };
            DirectoryInfo t = new DirectoryInfo(Path);

            while(t != null)
            {   
                ancestors.Add(t.FullName);
                t = t.Parent;
            }

            return ancestors;
        }
    }
}