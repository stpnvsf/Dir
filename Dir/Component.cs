using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    interface IComponent
    {
        public string Name { get; }
        public long Size { get; }
        
    }
}
