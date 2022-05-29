using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour, IEventCommand
{
	[CommandEvent("EventTest")]
	public void Execute()
	{
		Debug.Log("Test");
	}
}
