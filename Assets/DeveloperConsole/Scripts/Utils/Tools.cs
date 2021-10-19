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
	}
}
