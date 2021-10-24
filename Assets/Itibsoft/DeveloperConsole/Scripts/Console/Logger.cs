using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Logger : MonoBehaviour
	{
		public static Logger Instance;

		[SerializeField] private Scrollbar _scrollbar;
		[SerializeField] private TMP_Text _loggerText;

		public bool IsFullLog{ get; set; } = true;

		private void Awake() => Instance = this;

		public void AddLog(string log, ICommand command = null)
		{
			_loggerText.text += CurrentExecuteCommand(command);

			_loggerText.text += $"{Environment.NewLine}{log}";
			StartCoroutine(ScrollbarToEnd());
		}

		private string CurrentExecuteCommand(ICommand command)
		{
			if (!IsFullLog && !Tools.IsNull(command)) return null;

			string tempLog = $"{Tools.GetColoredRichText("Execute:", TypeColor.Green)} " +
				$"{command.ToString().Replace(command.GetType().Name, Tools.GetColoredRichText(command.GetType().Name, TypeColor.Yellow))}";
			return tempLog;
		}
		private IEnumerator ScrollbarToEnd()
		{
			yield return new WaitForSeconds(0.1f);
			_scrollbar.value = 0;
		}

		public void ClearLog() => _loggerText.text = "";
	}
}