using Itibsoft.ConsoleDeveloper.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class HelpCommand : ICommand
	{
		public override string Name => "Help";
		public override string Description => "Info more command";

		public override void Execute()
		{
			Debug.Log(Description);
		}
	}
}
