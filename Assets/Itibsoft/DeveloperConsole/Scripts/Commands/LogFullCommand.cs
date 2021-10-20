using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class LogFullCommand : ICommand
	{
		public override string Name => "Log.Full";

		public override string Description{ 
			get
			{
				if (Logger.Instance.IsFullLog)
				{
					return $"Logger full contoller[ {Tools.SetColorText("OFF", TypeColor.Red)} / {Tools.SetColorText("ON", TypeColor.Green)} ]";
				}
				else
				{
					return $"Logger full contoller[ {Tools.SetColorText("OFF", TypeColor.Green)} / {Tools.SetColorText("ON", TypeColor.Red)} ]";
				}
			} 
		}
		private bool _isColor = false;

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
