#if UNITY_EDITOR
using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class ConsoleDeveloperEditor : EditorWindow
{
	private bool _isEnabled = false;
	private bool _isMain;
	private Object _object;

	private List<Object> _list = new List<Object>();

	[MenuItem("Tools/Itibsoft/ConsoleDeveloper")]
	public static void ShowWindow()
	{
		GetWindow(typeof(ConsoleDeveloperEditor));
	}
	private void OnGUI()
	{
		GUIGroupNOMain();
	}

	private string _nameCommand;
	private string _descriptionCommand;
	private string _eventCommand;

	public List<ICommand> _commands = new List<ICommand>();

	private void GUIGroupNOMain()
	{
		_list = Resources.LoadAll("EventCommands", typeof(ICommand)).ToList();
		_nameCommand = EditorGUILayout.TextField("Name", _nameCommand);
		_descriptionCommand = EditorGUILayout.TextField("Description", _descriptionCommand);
		_eventCommand = EditorGUILayout.TextField("CommandEvent", _eventCommand);
		if (GUILayout.Button("Create"))
		{ 
			if (_nameCommand == "" | _descriptionCommand == "" | _eventCommand == "") return;

			EventCommand command = CreateInstance<EventCommand>();
			AssetDatabase.CreateAsset(command, $"Assets/Itibsoft/DeveloperConsole/Resources/EventCommands/{_nameCommand}.asset");
			AssetDatabase.SaveAssets();
			command.Name = _nameCommand;
			command.Description = _descriptionCommand;
			command.EventExecute = _eventCommand;
			_object = command;
			_commands.Add(command);
			CommandsList.Instance.Commands.Add(command);

			_nameCommand = "";
			_descriptionCommand = "";
			_eventCommand = "";

			_list.Add(command);
		}

		foreach (var item in _list)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.ObjectField(item, typeof(ICommand), true);

			if (GUILayout.Button("run")) ((ICommand)item).Execute();
			if (GUILayout.Button("info")) Debug.Log(((ICommand)item).Description);
			if (GUILayout.Button("del"))
			{
				AssetDatabase.DeleteAsset($"Assets/Itibsoft/DeveloperConsole/Resources/EventCommands/{((ICommand)item).Name}.asset");
			}
			EditorGUILayout.EndHorizontal();
		}
		
	}
}
#endif
