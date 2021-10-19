using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public Action<KeyCode> OnKeyDown;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			OnKeyDown(KeyCode.Return);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnKeyDown(KeyCode.Escape);
		}
	}
}
