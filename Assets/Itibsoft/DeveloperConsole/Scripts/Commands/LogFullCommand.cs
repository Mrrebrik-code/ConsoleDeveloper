using Itibsoft.ConsoleDeveloper.Console;
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;

namespace Itibsoft.ConsoleDeveloper.Commands
{
	public class LogFullCommand : AbstractCommand
	{
		public override string Name => "Log.Full";

		public override string Description{ 
			get
			{
				return $"Logger full contoller[ {Tools.GetColoredRichText("OFF", GetTypeColorForIsFullLogReverse())} / {Tools.GetColoredRichText("ON", GetTypeColorForIsFullLog())} ]";
			} 
		}
		
		private bool _isColor = false;

		public override void Execute()
		{
			base.Execute();

			Logger.Instance.IsFullLog = !Logger.Instance.IsFullLog;
			Logger.Instance.AddLog($"Logger IsFullLog = {Tools.GetColoredRichText(Logger.Instance.IsFullLog.ToString(), GetTypeColorForIsFullLog())}");
			
		}

		private TypeColor GetTypeColorForIsFullLog()
		{
			return Logger.Instance.IsFullLog ? TypeColor.Green : TypeColor.Red;
		}
		
		private TypeColor GetTypeColorForIsFullLogReverse()
		{
			return Logger.Instance.IsFullLog ? TypeColor.Red : TypeColor.Green;
		}
	}
}
