using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
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
	
		protected Upgrade(UpgradeConfig config, Button button)
		{
			name = config.name;
			cost = config.cost;
			level = config.level;
			this.button = button;
			button.GetComponentInChildren<Text>().text = name + Mathf.Round(cost).ToString(CultureInfo.InvariantCulture);
			List.Add(this);
		}
	}
}