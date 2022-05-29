using Itibsoft.ConsoleDeveloper.Utils;
using Itibsoft.ConsoleDeveloper.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using Logger = Itibsoft.ConsoleDeveloper.Console.Logger;

public class EventCommandManager : Singleton<EventCommandManager>
{
	private Dictionary<string, IEventCommand> _commands = new Dictionary<string, IEventCommand>();

	public override void Awake()
	{
		base.Awake();
		Initializtion();
	}

	private void Initializtion()
	{
		List<GameObject> rootObjectsInScene = new List<GameObject>();
		Scene scene = SceneManager.GetActiveScene();
		scene.GetRootGameObjects(rootObjectsInScene);

		var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		for (int i = 0; i < rootObjectsInScene.Count; i++)
		{
			var allComponents = rootObjectsInScene[i].GetComponentsInChildren<IEventCommand>(true);
			for (int j = 0; j < allComponents.Length; j++)
			{
				foreach (var field in allComponents[j].GetType().GetMethods(bindingFlags))
				{
					var att = field.GetCustomAttribute<CommandEventAttribute>();
					if (att != null) _commands.Add(att.EventString, allComponents[j]);
				}
			}
		}
	}

	public void InvokeCommand(string nameEvent)
	{
		if(_commands.ContainsKey(nameEvent) == false)
		{
			Logger.Instance.AddLog(Tools.GetColoredRichText("Not found command!", TypeColor.Red) + " - " + Tools.GetColoredRichText(nameEvent, TypeColor.Yellow));
			return;
		}
		var command = _commands[nameEvent];
		Debug.Log("asd");
		command.Execute();
	}
}
