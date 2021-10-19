using Itibsoft.ConsoleDeveloper.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Console
{
	public class ConsoleDeveloper : MonoBehaviour
	{
		[SerializeField] private InputHandler _inputHandler;
		[SerializeField] private Logger _logger;
		[SerializeField] private Buffer _buffer;
		[SerializeField] private Input _input;

		private Commands _commands = new Commands();

		private void Start()
		{
			_inputHandler.OnKeyDown += OnKeyHandler;
		}

		private void OnKeyHandler(KeyCode key)
		{
			switch(key)
			{
				case KeyCode.Escape:
					Debug.Log("Show");
					break;
				case KeyCode.Return:
					Send();
					break;
			}
		}

		public void Send()
		{
			ICommand command = _commands.GetCommand(_input.GetInputText());
			if (command != null) ExecuteCommand(command);
		}

		private void ExecuteCommand(ICommand command)
		{
			command.Execute();
			_logger.AddLog($"Execute: {command.ToString()}");
		}
	}
}
