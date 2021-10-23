using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConsoleDeveloperEditor : EditorWindow
{
	//ÿ¿¡ÀŒÕÕ¿ﬂ Õ¿ »ƒ ¿ ¡”ƒ”Ÿ≈√Œ Œ Õ¿ ..œ–Œ¬≈– ¿..
	private bool _isEnabled = false;

	private bool _isMain;

	[MenuItem("Window/Itibsoft/ConsoleDeveloper")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(ConsoleDeveloperEditor));
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
	private void GUIGroupNOMain()
	{
		if (GUILayout.Button("Click"))
		{
			_isMain = true;
		}
	}
}
