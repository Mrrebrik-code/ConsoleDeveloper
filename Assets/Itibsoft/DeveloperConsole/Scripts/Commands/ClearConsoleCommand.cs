using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class ClearConsoleCommand : ICommand
	{
		public override string Name => "Clear";

		public override string Description => "Clear console";

		public override void Execute()
		{
			Logger.Instance.ClearLog();
			HistoryCommands.Instance.ClearHistory();

			base.Execute();
		}
	}
}
