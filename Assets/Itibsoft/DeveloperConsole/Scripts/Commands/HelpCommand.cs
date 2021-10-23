using System;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class HelpCommand : AbstractCommand
	{
		public override string Name => "Help";
		public override string Description => "Info more command";

		public override void Execute()
		{
			base.Execute();

			var listCommands = Tools.GetColoredRichText("Commands:", TypeColor.Green) + Environment.NewLine;
			for (int i = 0; i < CommandsList.Commands.Count; i++)
			{
				listCommands += $"{i + 1}. {CommandsList.Commands[i].Name} - {CommandsList.Commands[i].Description}" + Environment.NewLine;
			}
			Logger.Instance.AddLog(listCommands);
		}
	}
}
