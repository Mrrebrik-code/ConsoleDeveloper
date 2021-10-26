using Itibsoft.ConsoleDeveloper.Core;
using Itibsoft.ConsoleDeveloper.Console;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class ConsoleDeveloperEditor : EditorWindow
{
	//ÿ¿¡ÀŒÕÕ¿ﬂ Õ¿ »ƒ ¿ ¡”ƒ”Ÿ≈√Œ Œ Õ¿ ..œ–Œ¬≈– ¿..
	private bool _isEnabled = false;
	private bool _isMain;
	private Object _object;

	[MenuItem("Window/Itibsoft/ConsoleDeveloper")]
	public static void ShowWindow()
	{
		GetWindow(typeof(ConsoleDeveloperEditor));
	}
	private void OnGUI()
	{
		if(_isMain) GUIGroupEnabled();
		else
		{
			GUIGroupNOMain();
		}
	}

	private void GUIGroupEnabled()
	{
		_isEnabled = EditorGUILayout.BeginToggleGroup("Enabled:", _isEnabled);
		if (GUILayout.Button("Click"))
		{
			_isMain = false;
		}
		EditorGUILayout.EndToggleGroup();
	}

	private string _nameCommand;
	private string _descriptionCommand;

	public List<ICommand> _commands = new List<ICommand>();

	private void GUIGroupNOMain()
	{
		if (GUILayout.Button("Click"))
		{
			_isMain = true;
		}
		_object = EditorGUILayout.ObjectField(_object, typeof(ICommand), true);
		_nameCommand = EditorGUILayout.TextField("Name", _nameCommand);
		_descriptionCommand = EditorGUILayout.TextField("Description", _descriptionCommand);
		if (GUILayout.Button("Create"))
		{
			EventCommand command = CreateInstance<EventCommand>();
			AssetDatabase.CreateAsset(command, $"Assets/Itibsoft/DeveloperConsole/Resources/EventCommands/{_nameCommand}.asset");
			AssetDatabase.SaveAssets();
			command.Name = _nameCommand;
			command.Description = _descriptionCommand;
			_object = command;
			_commands.Add(command);
			CommandsList.Instance.Commands.Add(command);
		}
		if(_object != null)
		{
			EditorGUILayout.LabelField(CommandsList.Instance.Commands.Count.ToString());
			SerializedObject serObj = new SerializedObject(_object);
			SerializedProperty serProp = serObj.FindProperty("EventExecute");
			EditorGUILayout.PropertyField(serProp);
			serObj.ApplyModifiedProperties();
		}
		
		


	}
}
