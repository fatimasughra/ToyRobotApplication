using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ToyRobotLibrary;
using ToyRobotLibrary.Interfaces;

namespace TelstraRobotToy
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobot maxRobot = new ToyRobot();
            string inputCommand;
            do
            {
                
                inputCommand = Console.ReadLine();

                if (inputCommand.Trim().ToUpper() == "STOP")
                    break;

                var action = maxRobot.Execute(inputCommand);

                Console.WriteLine(action.CommandAction);

            } while (true);
        }
    }
}
