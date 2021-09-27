using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{



	/*
	Robot - There will be a robot object which will take commands and execute them,
	We will define a Robot class which will be implementing the IRobot.
	Why are we taking IRobot interface? Because we need to have flexibility. 
	If later on we introduce another version of the Robot with slighly different behavior e.g.flying
	*/
	


	public class ToyRobot : IRobot
	{
		private IRobotPosition _currentPosition;

		public ICommand CurrentCommand { get; private set; }
		private IProcessor MyProcessor { get;  set; }

		public ToyRobot()
		{
			MyProcessor = new Processor();
			Console.WriteLine("Hello! I am Max, the Toy Robot." +
				"\r\n\r\nGuess what? I am not case-sensitive. \r\nI am capable to take the commands as follows:" +
				"\r\n\tPLACE X,Y,DIRECTION" +
				"\r\n\tMOVE\r\n\tLEFT\r\n\tRIGHT\r\n\tREPORT\r\n\tSTOP\r\nWhat would you like me to do?");

			_currentPosition = new RobotPosition();
		}

		public void Prepare(ICommand command)
		{

			CurrentCommand = command;
			CurrentCommand.Prepare(_currentPosition);
		}

		public IRobotAction Execute(string instructions)
		{
			ICommand command;

			//This method will parse the instruction and set up the command object
			MyProcessor.Run(instructions, out command);

			//This method will initialize the variables that will be used for action
			command.Prepare(_currentPosition);

			//This will validate command with attributes defined for Command class
			var result = ValidatorHelper.Validate(command);

			//Action time
			if (result.FirstOrDefault() == ValidationResult.Success)
				return command.Action(ref _currentPosition);
			else
				return new RobotAction(result.FirstOrDefault().ErrorMessage);
		}
		
	}



}
