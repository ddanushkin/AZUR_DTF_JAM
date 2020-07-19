using Game.UnityComponents;

namespace Game
{
	public class HandSpeedUpgrade : Upgrade
	{
		public static HandSpeedUpgrade Instance;
		public override void Process(ref ClockComponent clock)
		{
			clock.HandSpeed += level * 1.25f;
			level += 1;
			cost += cost * 2f;
		}

		public HandSpeedUpgrade(UpgradeConfig config) : base(config)
		{
			Instance = this;
		}
	}
}