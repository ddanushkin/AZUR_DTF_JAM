namespace Game
{
	public class ReloadSpeedUpgrade : Upgrade
	{
		public ReloadSpeedUpgrade(UpgradeConfig config) : base(config)
		{
		}

		public override void Process(ref ClockComponent clock)
		{
			clock.SpeedHandBack += level * 0.25f;
			level += 1;
			cost += cost * 0.02f;
		}
	}
}