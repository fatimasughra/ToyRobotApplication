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
                string cmd = command[0].Trim().ToUpper();
                if (cmd == "PLACE" && command.Length > 1)
                {
                    var args = command[1].Split(',');
                    if (args.Length == 2)
                        commandObj = new PLACECommand(Int32.Parse(args[0].Trim()),
                                                   Int32.Parse(args[1].Trim()));
                    if (args.Length == 3)
                        commandObj = new PLACECommand(Int32.Parse(args[0].Trim()),
                                                   Int32.Parse(args[1].Trim()),
                                                   Enum.Parse<DIRECTION>(args[2].Trim().ToUpper()));
                }

                else if (cmd == "MOVE")
                    commandObj = new MOVECommand();

                else if (cmd == "LEFT")
                    commandObj = new LEFTCommand();

                else if (cmd == "RIGHT")
                    commandObj = new RIGHTCommand();

                else if (cmd == "REPORT")
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