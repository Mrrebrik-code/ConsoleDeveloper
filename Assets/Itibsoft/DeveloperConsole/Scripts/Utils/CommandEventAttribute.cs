using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Method)]
public class CommandEventAttribute : Attribute
{
	public string EventString;
	public CommandEventAttribute(string eventName)
	{
		EventString = eventName;
	}
}
