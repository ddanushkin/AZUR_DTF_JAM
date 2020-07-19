namespace Game
{
	public class HandSpeedUpgrade : Upgrade
	{
		public override void Process(ref ClockComponent clock)
		{
			clock.HandSpeed += level * 0.25f;
			level += 1;
			cost += cost * 0.02f;
		}

		public HandSpeedUpgrade(UpgradeConfig config) : base(config) {}
	}
}