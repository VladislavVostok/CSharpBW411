using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Interfaces.Interfaces
{
    internal class Class1 : IWorker
    {
        public bool IsWorking {get; set;}

        public event EventHandler WorkEnded;

        public string Work()
        {
            WorkEnded?.Invoke(this, EventArgs.Empty);
            return "";
        }
    }
}
