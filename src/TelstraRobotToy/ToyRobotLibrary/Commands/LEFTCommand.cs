using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.Commands
{
	class LEFTCommand : Command
	{
		protected override void Prepare()
        {
			IRobotPosition position = CurrentRobotContext.CurrentPosition;

			_newPosition = new RobotPosition();

			_newPosition.X = position.X;
			_newPosition.Y = position.Y;

			if (position.Direction == DIRECTION.NORTH) //value = 0, then reset value to 3 i.e. WEST
				_newPosition.Direction = DIRECTION.WEST;

			else
				_newPosition.Direction = position.Direction-1;

		}
	}

}
