using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotLibrary.Interfaces
{
    public interface IRobotContext
    {
        IRobotPosition CurrentPosition { get; }
      
        void Save(IRobotPosition position);
    }
}
