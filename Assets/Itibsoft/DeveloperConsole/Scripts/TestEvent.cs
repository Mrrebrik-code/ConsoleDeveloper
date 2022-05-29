using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour, IEventCommand
{
	[SerializeField] private GameObject _gameObject;
	private bool _isActive = false;

	[CommandEvent("OnOfGameObject")]
	public void Execute()
	{
		_isActive = !_isActive;
		_gameObject.SetActive(_isActive);
	}
}
