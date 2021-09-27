using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.Commands
{
	//PLACE Command
	/*
	PLACE Command will take 3 arguments X, Y, DIRECTION
	 we will define the constructor and will pass the arguments into the constructor. 
	Please note Conditions of PLACECommand. We will cater most conditions while desinging our validations
	 	- PLACECommand should be the first command the robot should take. 
		- The new position should be within the table
	*/

	class PLACECommand : Command, IPlaceableCommand, IPositionChangingCommand
	{
		public PLACECommand(int x, int y)
		{
			_newPosition = new RobotPosition();
			_newPosition.X = x;
			_newPosition.Y = y;
			
			
		}
		public PLACECommand(int x, int y, DIRECTION direction)
		{
			_newPosition = new RobotPosition();
			_newPosition.X = x;
			_newPosition.Y = y;
			_newPosition.Direction = direction;

			
		}
		protected override void Prepare()
		{
			if(_newPosition.Direction == DIRECTION.NODIRECTION)
				_newPosition.Direction = CurrentRobotContext.CurrentPosition.Direction;

		}


	}
}
