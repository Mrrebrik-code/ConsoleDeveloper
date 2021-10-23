using Itibsoft.ConsoleDeveloper.Utils;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Core
{
	public abstract class AbstractCommand
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public virtual void Execute()
		{
			Console.Logger.Instance.AddLog($"{Tools.GetColoredRichText("Execute:", TypeColor.Green)} " +
				$"{this.ToString().Replace(this.GetType().Name, Tools.GetColoredRichText(this.GetType().Name, TypeColor.Yellow))}");
		}
	}
}
