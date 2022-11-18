using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal class Dir : IComponent
    {
        public string Name { get; }
        public long Size { get; }

        public Dictionary<string, int> FrequencyByType { get; }
        public double AverageSize { get; private set; }
        public List<IComponent> Components { get; }
        
        public Dir(string name, long size = 0) 
        {
            Name = name;
        }

        public double getAverageSize(string path)
        {
            AverageSize = Components.Sum(x => x.Size) / Components.Count();

            return AverageSize;
        }

        public void Add(IComponent c)
        {
            Components.Add(c);
        }

        public void Remove(IComponent c)
        {
            Components.Remove(c);
        }

        //public void getChildren(string path)
        //{
        //    //var t = (Directory.GetDirectories(path));
        //    //_files.AddRange(Directory.GetFiles(path));

        //    //foreach (var subdir in Directory.GetDirectories(path))
        //    //{

        //    //    getChildren(subdir);
        //    //}

        //}

        public Dictionary<string, int> getTypeFrequency(string path)
        {
            var files = Components.OfType<IFile>();

            files.GroupBy(x => x.Type)
                             .OrderBy(y => y.Key)
                             .Select(g => string.Format("Value: {0}; Count: {1};", g.Key, g.Count()));

            foreach (IFile file in files)
            {

            }

            return new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }

        

    }
}
