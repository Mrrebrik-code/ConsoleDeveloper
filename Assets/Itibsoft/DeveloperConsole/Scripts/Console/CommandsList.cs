using Itibsoft.ConsoleDeveloper.Commands;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class CommandsList : MonoBehaviour
	{
		public static CommandsList Instance;
		public List<ICommand> AddingCommands = new List<ICommand>
		{
			new HelpCommand(),
			new LogFullCommand(),
			new ClearConsoleCommand()
		};
		public List<ICommand> Commands = new List<ICommand>();

		private void Awake()
		{
			Instance = this;
			Commands.AddRange(AddingCommands);
			var temp = Resources.LoadAll("EventCommands", typeof(ICommand));
			foreach (var commandObject in temp)
			{
				if(commandObject is ICommand command)
				{
					Commands.Add(command);
				}
			}
		}
		public ICommand GetCommand(string name)
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
