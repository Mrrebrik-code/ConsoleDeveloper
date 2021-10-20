using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class LogFullCommand : ICommand
	{
		public override string Name => "Hels";//Log.Full

		public override string Description => $"Logger full contoller[ {Tools.SetColorText("OFF", TypeColor.Red)} / {Tools.SetColorText("ON", TypeColor.Green)} ]";

		public override void Execute()
		{
			base.Execute();

			Logger.Instance.IsFullLog = !Logger.Instance.IsFullLog;
			if (Logger.Instance.IsFullLog)
			{
				Logger.Instance.AddLog($"Logger IsFullLog = {Tools.SetColorText(Logger.Instance.IsFullLog.ToString(), TypeColor.Green)}");
			}
			else
			{
				Logger.Instance.AddLog($"Logger IsFullLog = {Tools.SetColorText(Logger.Instance.IsFullLog.ToString(), TypeColor.Red)}");
			}
			
		}
	}
}
