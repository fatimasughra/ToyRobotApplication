using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Commands;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
    public class Processor:IProcessor
    {
        public void Run(string instructions, out ICommand commandObj)
        {
            commandObj = null;
            try
            {
                string[] command = instructions.Split(' ');
                if (command[0] == "PLACE" && command.Length > 1)
                {
                    var args = command[1].Split(',');
                    if (args.Length == 2)
                        commandObj = new PLACECommand(Int32.Parse(args[0]),
                                                   Int32.Parse(args[1]));
                    if (args.Length == 3)
                        commandObj = new PLACECommand(Int32.Parse(args[0]),
                                                   Int32.Parse(args[1]),
                                                   Enum.Parse<DIRECTION>(args[2]));
                }

                else if (command[0] == "MOVE")
                    commandObj = new MOVECommand();

                else if (command[0] == "LEFT")
                    commandObj = new LEFTCommand();

                else if (command[0] == "RIGHT")
                    commandObj = new RIGHTCommand();

                else if (command[0] == "REPORT")
                    commandObj = new REPORTCommand();
            }
            catch
            {
            }
            finally
            {
                if (commandObj is null)
                    commandObj = new UnrecognizedCommand();
            }
        }
    }
}