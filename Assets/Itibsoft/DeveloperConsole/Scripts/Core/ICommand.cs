using Itibsoft.ConsoleDeveloper.Utils;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Core
{
	public abstract class ICommand
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public virtual void Execute()
		{
			Console.Logger.Instance.AddLog($"{Tools.SetColorText("Execute:", TypeColor.Green)} " +
				$"{this.ToString().Replace(this.GetType().Name, Tools.SetColorText(this.GetType().Name, TypeColor.Yellow))}");
		}
	}
}
