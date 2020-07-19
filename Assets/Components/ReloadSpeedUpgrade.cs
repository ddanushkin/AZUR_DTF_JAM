using System.Globalization;
using Game.UnityComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class ReloadSpeedUpgrade : Upgrade
	{
		public static ReloadSpeedUpgrade Instance;
		public ReloadSpeedUpgrade(UpgradeConfig config) : base(config)
		{
			Instance = this;
		}

		public override void Process(ref ClockComponent clock)
		{
			cost = 100 * Mathf.Pow(1.47F, level);
			clock.SpeedHandBack += Mathf.Log(clock.HandSpeed);
			level += 1;
			cost = 100 * Mathf.Pow(1.47F, level);
			button.GetComponentInChildren<Text>().text = name + Mathf.Round(cost).ToString(CultureInfo.InvariantCulture);

		}
	}
}