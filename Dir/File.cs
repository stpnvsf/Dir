using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal class File
    {
        private string _path;
        public string Name { get; }
        public long Size { get; }
        public string Type { get; }

        public File(string path)
        {
            _path = path;
            var fileInfo = new FileInfo(path);
            Name = fileInfo.Name;
            Size = fileInfo.Length;
            Type = fileInfo.Extension;
        }
    }
}
