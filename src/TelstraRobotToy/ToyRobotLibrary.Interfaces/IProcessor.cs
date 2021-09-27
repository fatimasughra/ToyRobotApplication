using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotLibrary.Interfaces
{
	public interface IProcessor
	{
		void Run(string Instructions, out ICommand command);
	}

}
