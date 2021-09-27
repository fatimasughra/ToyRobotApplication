using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
	[InvalidCommandValidation]
	[RobotNotPlacedValidation]
	[InvalidPositionValidation]
	abstract class Command : ICommand
	{
		protected IRobotPosition _newPosition;

		public IRobotContext CurrentRobotContext { get; private set; }

		public IRobotPosition NewPositionInstruction { get { return _newPosition; } }


		//Methods
		public void Prepare(IRobotPosition currentPosition)
		{
			CurrentRobotContext = new RobotContext(currentPosition);
			Prepare();
		}

		protected abstract void Prepare();

		public virtual IRobotAction Action(ref IRobotPosition currentPosition)
		{
			if(_newPosition is not null)
				currentPosition = _newPosition;
			return GetCommandExecutedAction();
		}
		protected virtual IRobotAction GetCommandExecutedAction()
		{
			return new RobotAction(ROBOTRESPONSE.COMMAND_EXECUTED);
		}
	}

	 class UnrecognizedCommand : Command
    {
        protected override void Prepare()
        {
            //throw new Exception("Command is not known");
        }
    }
}
