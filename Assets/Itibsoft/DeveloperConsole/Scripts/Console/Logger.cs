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

		public bool IsFullLog = true;

		private void Awake() => Instance = this;

		public void AddLog(string log)
		{
			if (!IsFullLog && log.Contains("Execute")) return;

			_loggerText.text += $"\n{log}";
			StartCoroutine(ScrollbarToEnd());
		}

		private IEnumerator ScrollbarToEnd()
		{
			yield return new WaitForSeconds(0.1f);
			_scrollbar.value = 0;
		}

		public void ClearLog() => _loggerText.text = "";
	}
}