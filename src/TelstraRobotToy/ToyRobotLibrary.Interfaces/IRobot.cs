using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotLibrary.Interfaces
{

	public interface IRobot
	{
		void Prepare(ICommand command);
		IRobotAction Execute(string instructions);
	}

	
}
