using Itibsoft.ConsoleDeveloper.Commands;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System.Collections.Generic;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Commands
	{
		private List<ICommand> _commands = new List<ICommand>
		{
			new HelpCommand()
		};

		public ICommand GetCommand(string name)
		{
			if (Tools.IsNull(name)) return null;

			ICommand tempCommand = null;

			foreach (var command in _commands)
			{
				if(command.Name == name)
				{
					tempCommand = command;
					break;
				}
			}

			return tempCommand;
		}
	}
}
