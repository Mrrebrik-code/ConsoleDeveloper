﻿using UnityEngine;
using TMPro;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Input : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _inputField;

		public string GetInputText()
		{
			return _inputField.text;
		}

		public void ClearInputField()
		{
			_inputField.text = "";
		}

		public void TrimImputText()
		{
			if (!_inputField.text.Contains("/"))
			{
				var tempText = _inputField.text.Insert(0, "/");
				_inputField.text = tempText;
			}
				
		}
	}
}