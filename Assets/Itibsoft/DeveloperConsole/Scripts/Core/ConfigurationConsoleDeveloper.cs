using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Itibsoft.ConsoleDeveloper.Core
{
	public class ConfigurationConsoleDeveloper : ScriptableObject
	{
		[SerializeField] private string _nameGame;
		[SerializeField] private string _versionGame;
		[SerializeField] private string _companyName;
	}
}
