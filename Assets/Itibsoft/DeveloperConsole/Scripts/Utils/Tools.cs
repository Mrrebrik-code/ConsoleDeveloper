using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Utils
{
	public static class Tools
	{
		public static bool IsNull(string text)
		{
			if (text == null || text.Contains(" ") || text == "") return true;
			return false;
		}

		public static string SetColorText(string text, TypeColor color)
		{
			var textColor = "";
			switch (color)
			{
				case TypeColor.Red:
					textColor = $"<color=\"red\">{text}</color=\"red\">";
					break;
				case TypeColor.Green:
					textColor = $"<color=\"green\">{text}</color=\"green\">";
					break;
				case TypeColor.Blue:
					textColor = $"<color=\"blue\">{text}</color=\"blue\">";
					break;
				case TypeColor.Yellow:
					textColor = $"<color=\"yellow\">{text}</color=\"yellow\">";
					break;
			}
			return textColor;
		}

		public static bool Cotains(string text, string search, bool toLower = false)
		{
			var tempText = toLower ? text.ToLower() : text;

			if (tempText.Contains(search)) return true;
			else return false;
		}

		public static bool Compare(string one, string two)
		{
			return one == two;
		}
	}
}
