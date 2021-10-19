using TMPro;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Logger : MonoBehaviour
	{
		[SerializeField] private TMP_Text _loggerText;

		public void AddLog(string log)
		{
			_loggerText.text += $"\n{log}";
		}
	}
}