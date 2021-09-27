using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
	
	public class RobotPosition:IRobotPosition
	{

		
		public const int MAX_X = 6;
		public const int MAX_Y = 6;

		public int X { get; set; }

		public int Y { get; set; }

		public DIRECTION Direction { get; set; }

        public RobotPosition()
        {
			X = -1;
			Y = -1;
			Direction = DIRECTION.NODIRECTION;
        }

	}



}
