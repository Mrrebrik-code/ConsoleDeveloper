using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class HelpCommand : ICommand
	{
		public override string Name => "Help";
		public override string Description => "Info more command";

		public override void Execute()
		{
			base.Execute();

			var listCommands = Tools.SetColorText("Commands:", TypeColor.Green) + "\n";
			for (int i = 0; i < CommandsList.Commands.Count; i++)
			{
				listCommands += $"{i + 1}. {CommandsList.Commands[i].Name} - {CommandsList.Commands[i].Description}" + "\n";
			}
			Logger.Instance.AddLog(listCommands);
		}
	}
}
