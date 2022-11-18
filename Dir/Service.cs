using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal class Service
    {
        public IComponent MainDir { get; set;}
        Service(string path)
        { 
            var dirInfo = new DirectoryInfo(path);
            IComponent component = new Dir(dirInfo.Name);
        }

        public void FillWithComponents(string path)
        {
            //t = (Directory.GetDirectories(path));
            //t.AddRange(Directory.GetFiles(path));

            //foreach (var subdir in Directory.GetDirectories(path))
            //{

            //    FillWithComponents(subdir);
            //}

        }
        private IComponent deserializeFile(string path) 
        {
            var fileInfo = new FileInfo(path);
            IComponent file = new File(fileInfo.Name, fileInfo.Extension, fileInfo.Length);
            
            return file;
        }
        private IComponent deserializeDirectory(string path) 
        {
            var fileInfo = new FileInfo(path);
            IComponent file = new Dir(fileInfo.Name, fileInfo.Length);
            
            return file;
        }

    }
}
