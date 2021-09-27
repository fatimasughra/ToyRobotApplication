using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.Commands
{
    class REPORTCommand:Command
    {
        string _message;
        protected override void Prepare()
        {
            var position = CurrentRobotContext.CurrentPosition;
            _message = string.Format( ROBOTRESPONSE.REPORT_RESPONSE_FORMAT, position.X, position.Y, position.Direction.ToString());
        }
        protected override IRobotAction GetCommandExecutedAction()
        {
            return new RobotAction(_message);

        }
    }
}
