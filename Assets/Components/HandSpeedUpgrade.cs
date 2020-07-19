using Game.UnityComponents;
using UnityEngine;

namespace Game
{
	public class HandSpeedUpgrade : Upgrade
	{
		private const float BaseSpeed = 6f;
		public float BonusSpeed;
		public static HandSpeedUpgrade Instance;
		public override void Process(ref ClockComponent clock)
		{
			clock.HandSpeed += Mathf.Log(clock.HandSpeed);
			level += 1;
			cost = 100 * Mathf.Pow(1.47F, level);
			BonusSpeed = clock.HandSpeed % BaseSpeed;
			Debug.Log(clock.HandSpeed + " " + cost);
		}

		public HandSpeedUpgrade(UpgradeConfig config) : base(config)
		{
			Instance = this;
		}
	}
}