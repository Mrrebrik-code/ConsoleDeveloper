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
			new LogFullCommand(),
			new ClearConsoleCommand()
		};

		public static ICommand GetCommand(string name)
		{
			if (Tools.IsNull(name)) return null;

			ICommand tempCommand = null;

			foreach (var command in Commands)
			{
				if(command.Name.ToLower() == name.ToLower().Trim('/'))
				{
					tempCommand = command;
					break;
				}
			}

			return tempCommand;
		}
	}
}
