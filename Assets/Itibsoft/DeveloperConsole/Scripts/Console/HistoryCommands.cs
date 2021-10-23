using Itibsoft.ConsoleDeveloper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class HistoryCommands
	{
		public static HistoryCommands Instance;

		private List<AbstractCommand> _historyCommands = new List<AbstractCommand>();
		private int _index = default;

		public HistoryCommands() => Instance = this;

		public void AddHistory(AbstractCommand command)
		{
			_historyCommands.Add(command);
			_index = _historyCommands.Count - 1;
		}

		public AbstractCommand GetCommandFromHistory(bool vector)
		{
			if (_historyCommands.Count < 1) return null;

			if (vector) _index++;
			else _index--;

			if (_index < 0) _index = 0;
			else if (_index >= _historyCommands.Count) _index = _historyCommands.Count - 1;

			return _historyCommands[_index];
		}

		public void ClearHistory()
		{
			_historyCommands = new List<AbstractCommand>();
			_index = default;
		}
	}
}
