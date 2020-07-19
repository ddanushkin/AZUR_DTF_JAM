using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Game.UnityComponents
{
	[CreateAssetMenu(menuName = "Game Assets/New Configuration File")]
	[Serializable]
	class Configuration : ScriptableObject
	{
		public List<UpgradeConfig> upgradeConfigs = new List<UpgradeConfig>();

		public UpgradeConfig FindUpgradeConfig(string upgradeName)
		{
			return upgradeConfigs.Find(config => config.name == upgradeName);
		}

		// private void OnValidate()
		// {
		// 	var subclassTypes = Assembly
		// 		.GetAssembly(typeof(Upgrade))
		// 		.GetTypes()
		// 		.Where(t => t.IsSubclassOf(typeof(Upgrade)));
		// 	foreach (var subclassType in subclassTypes)
		// 	{
		// 		Debug.Log(subclassType.Name);
		// 	}
		// }
	}

	[Serializable]
	public class UpgradeConfig
	{
		public string name;
		public float cost;
		public int level;
	}
}