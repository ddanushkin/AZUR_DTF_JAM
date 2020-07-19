using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Assets/New Configuration File")]
[Serializable]
class Configuration : ScriptableObject
{
	public List<UpgradeConfig> upgradeConfigs = new List<UpgradeConfig>();

	public UpgradeConfig FindUpgradeConfig(string upgradeName)
	{
		return upgradeConfigs.Find(config => config.name == upgradeName);
	}
	
}

[Serializable]
public abstract class Upgrade
{
	public static List<Upgrade> List = new List<Upgrade>();
	public int level;
	public float cost;
	public string name;

	public abstract void Process(ref ClockComponent clock);

	public static Upgrade Find(string name)
	{
		return List.Find(upgrade => upgrade.name == name);
	}
	
	protected Upgrade(UpgradeConfig config)
	{
		name = config.name;
		cost = config.cost;
		level = config.level;
		List.Add(this);
	}
}

[Serializable]
public class UpgradeConfig
{
	public string name;
	public float cost;
	public int level;
}