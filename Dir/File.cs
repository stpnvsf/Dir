using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal class File : IFile
    {
        public string Name { get; }
        public long Size { get; }
        public string Type { get; }

        public File(string name, string type, long size)
        {
            Name = name;
            Size = size;
            Type = type;
        }
    }
}
