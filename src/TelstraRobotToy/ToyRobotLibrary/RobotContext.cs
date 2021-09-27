using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
    class RobotContext : IRobotContext
    {
        public IRobotPosition CurrentPosition { get; private set; }

        public IRobotAction ActionResult{get; private set;}

        public RobotContext()
        {

        }

        public RobotContext(IRobotPosition position)
        {
            Save(position);
        }

        public void Save(IRobotPosition position)
        {
            CurrentPosition = position;
        }
    }
}
