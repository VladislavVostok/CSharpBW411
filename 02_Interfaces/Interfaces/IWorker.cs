using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Interfaces.Interfaces
{
    public interface IWorker
    {
        event EventHandler WorkEnded;
        bool IsWorking { get; }
        string Work();
    }
}
