using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
    public class ROBOTRESPONSE
    {
        public const string COMMAND_EXECUTED = "Done Master !";
        public const string REPORT_RESPONSE_FORMAT = "Output: {0},{1},{2}";
        public const string INVALID_COMMAND_RESPONSE = "Ummm. Not sure what you're saying. I think I need to read more books. Meanwhile can you enter the commands that I can understand";
        public const string INVALID_POISITION_RESPONSE = "Whoa Whoaa Whoaaa. I was just about to fall from the table pal.";
        public const string INVALID_DIRECTION_RESPONSE = "I don't have any clue where to go. Can you please tell me the direction as well.";
        public const string ROBOT_NOT_PLACED_RESPONSE = "Pssst. I am trying to ignore but I think you have forgotten to put me on the table";

    }
    public class RobotAction : IRobotAction
    {
        public string CommandAction { get; private set; }

        public RobotAction(string action)
        {
            CommandAction = action;
        }
    }
}
