using UnityEngine;
using TMPro;
namespace Itibsoft.ConsoleDeveloper.Console
{
	public class Input : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _inputField;

		public string GetInputText()
		{
			return _inputField.text;
		}
	}
}