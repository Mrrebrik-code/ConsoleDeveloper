using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class HelpCommand : ICommand
	{
		public override string Name => "Help";
		public override string Description => "Info more command";

		public override void Execute()
		{
			Console.Logger.Instance.AddLog($"{Tools.SetColorText("Execute:", TypeColor.Red)} " +
				$"{this.ToString().Replace(this.GetType().Name, Tools.SetColorText(this.GetType().Name, TypeColor.Yellow))}");

			var listCommands = Tools.SetColorText("Commands:", TypeColor.Green) + "\n";
			for (int i = 0; i < CommandsList.Commands.Count; i++)
			{
				listCommands += $"{i + 1}. {CommandsList.Commands[i].Name} - {CommandsList.Commands[i].Description}" + "\n";
			}
			Console.Logger.Instance.AddLog(listCommands);
		}
	}
}
