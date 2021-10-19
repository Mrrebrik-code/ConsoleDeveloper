using Itibsoft.ConsoleDeveloper.Commands;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System.Collections.Generic;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public static class CommandsList
	{
		public static List<ICommand> Commands = new List<ICommand>
		{
			new HelpCommand(),
			new LogFullCommand()
		};

		public static ICommand GetCommand(string name)
		{
			if (Tools.IsNull(name)) return null;

			ICommand tempCommand = null;

			foreach (var command in Commands)
			{
				if(command.Name.ToLower() == name.ToLower())
				{
					tempCommand = command;
					break;
				}
			}

			return tempCommand;
		}
	}
}
