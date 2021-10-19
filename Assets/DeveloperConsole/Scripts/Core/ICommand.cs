using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Core
{
	public abstract class ICommand
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public virtual void Execute() => Debug.Log("Command empty");
	}
}
