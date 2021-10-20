using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public Action<KeyCode> OnKeyDown;
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Return)) OnKeyDown(KeyCode.Return);
		if (Input.GetKeyDown(KeyCode.BackQuote)) OnKeyDown(KeyCode.BackQuote);
		if (Input.GetKeyDown(KeyCode.UpArrow)) OnKeyDown(KeyCode.UpArrow);
		if (Input.GetKeyDown(KeyCode.DownArrow)) OnKeyDown(KeyCode.DownArrow);
	}
}
