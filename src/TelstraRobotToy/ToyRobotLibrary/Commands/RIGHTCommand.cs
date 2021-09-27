using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.Commands
{
	class RIGHTCommand : Command
	{
		protected override void Prepare()
        {
			var position = CurrentRobotContext.CurrentPosition;
			_newPosition = new RobotPosition();
			_newPosition.X = position.X;
			_newPosition.Y = position.Y;

			if (position.Direction == DIRECTION.WEST) //value = 3, then reset value to 0 i.e. NORTH
				_newPosition.Direction = DIRECTION.NORTH;

			else
				_newPosition.Direction = position.Direction+1;

		}

	}
}
