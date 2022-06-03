using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Utils;
using System;
using TMPro;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class ConsoleDeveloper : MonoBehaviour
	{
		[SerializeField] private InputHandler _inputHandler;
		[SerializeField] private GameObject _consoleObject;
		[SerializeField] private GameObject _inputDefaultObject;
		[SerializeField] private Logger _logger;
		[SerializeField] private Buffer _buffer;
		[SerializeField] private Input[] _inputs;
		[SerializeField] private TMP_Text _versionConsoleText;
		[SerializeField] private bool _isDefault = false;

		private HistoryCommands _history = new HistoryCommands();

		private void Start()
		{
			_inputHandler.KeyDownEvent += OnKeyHandler;
			_versionConsoleText.text = $"ConsoleDeveloper v{Application.version} by Itibsoft";
		}

		private void OnKeyHandler(KeyCode key)
		{
			switch(key)
			{
				case KeyCode.BackQuote:
					if (_isDefault == false) _consoleObject.SetActive(!_consoleObject.activeInHierarchy);
					else _inputDefaultObject.SetActive(!_inputDefaultObject.activeInHierarchy);
					break;
				case KeyCode.Return:
					Send();
					break;
				case KeyCode.UpArrow:
					GetHistoryCommandToInput(vector: true);
					break;
				case KeyCode.DownArrow:
					GetHistoryCommandToInput(vector: false);
					break;
			}
		}

		public void GetHistoryCommandToInput(bool vector)
		{
			foreach (var input in _inputs)
			{
				if (input.IsAllowInput)
				{
					ICommand command = _history.GetCommandFromHistory(vector);
					if (command != null) input.SetInputText(command.Name);
				}
			}
			
		}
		public void Send()
		{
			foreach (var input in _inputs)
			{
				ICommand command = CommandsList.Instance.GetCommand(input.GetInputText());

				if (command != null) ExecuteCommand(command);
				else Logger.Instance.AddLog(Tools.GetColoredRichText($"Error: ", TypeColor.Red) + input.GetInputText() + " - " + Tools.GetColoredRichText("This command is not recognized", TypeColor.Yellow) + Environment.NewLine);

				input.ClearInputField();
			}
			
		}

		private void ExecuteCommand(ICommand command)
		{
			_history.AddHistory(command);
			command.Execute();
		}
	}
}
