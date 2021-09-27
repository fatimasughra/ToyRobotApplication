using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotLibrary.Interfaces
{
    public enum DIRECTION
    {
        NODIRECTION = 0,
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    public interface IRobotPosition
    {
        int X { get; set; }

         int Y { get; set; }

         DIRECTION Direction { get; set; }

    }
}
