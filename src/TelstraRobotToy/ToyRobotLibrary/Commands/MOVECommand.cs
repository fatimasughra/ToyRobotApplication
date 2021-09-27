using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.Commands
{
	//MOVE Command - it will move the robot one place forward in the direction it is currently facing
	class MOVECommand : Command, IPositionChangingCommand
	{

		public MOVECommand()
		{
		}
		protected override void Prepare()
		{

			var position = CurrentRobotContext.CurrentPosition;
			_newPosition = new RobotPosition();

			_newPosition.Direction = position.Direction;
			_newPosition.X = position.X;
			_newPosition.Y = position.Y;

			switch (position.Direction)
			{
				case DIRECTION.NORTH:
					_newPosition.Y++;
					break;
				case DIRECTION.SOUTH:
					_newPosition.Y--;
					break;
				case DIRECTION.EAST:
					_newPosition.X++;
					break;
				case DIRECTION.WEST:
					_newPosition.X--;
					break;
			}

		}

	}
}

