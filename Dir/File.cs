using System;
using System.Collections.Generic;
using System.Linq;
namespace Dir
{
    public class File
    {
        public readonly string Path;
        public string Name { get; }
        public long Size { get; }
        public string Type { get; }

        public File(string path)
        {
            Path = path;
            var fileInfo = new FileInfo(path);
            Name = fileInfo.Name;
            Size = fileInfo.Length;
            Type = fileInfo.Extension;
        }
    }
}
