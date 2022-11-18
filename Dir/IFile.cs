using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    internal interface IFile : IComponent
    {
        string Type { get; }

    }
}
