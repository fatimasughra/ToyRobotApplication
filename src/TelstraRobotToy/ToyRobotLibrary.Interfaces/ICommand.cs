using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotLibrary.Interfaces
{
	/*
	Command - The robot will take commands PLACE, MOVE, LEFT, RIGHT, REPORT
	SO we will define the interface ICommand and implement classes for each command
	*/

	
	public interface ICommand
	{
		IRobotContext CurrentRobotContext { get; }
		IRobotPosition NewPositionInstruction { get; }

		//Methods
		//void Validate();
		void Prepare(IRobotPosition currentPosition);
		IRobotAction Action(ref IRobotPosition currentPosition);
	}


	public interface IPlaceableCommand:ICommand
	{

	}

	public interface IPositionChangingCommand : ICommand
	{

	}
}
