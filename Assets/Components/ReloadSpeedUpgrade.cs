using Game.UnityComponents;

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
			clock.SpeedHandBack += level * 0.25f;
			level += 1;
			cost += cost * 0.02f;
		}
	}
}