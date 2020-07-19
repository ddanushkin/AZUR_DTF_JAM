using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Game.UnityComponents
{
	[Serializable]
	public abstract class Upgrade
	{
		public static List<Upgrade> List = new List<Upgrade>();
		public int level;
		public float cost;
		public string name;
		public Button button;


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
}