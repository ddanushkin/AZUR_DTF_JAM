namespace Game
{
	public class HandSpeedUpgrade : Upgrade
	{
		public override void Process(ref ClockComponent clock)
		{
			clock.HandSpeed += level * 1.25f;
			level += 1;
			cost += cost * 2f;
		}

		public HandSpeedUpgrade(UpgradeConfig config) : base(config) {}
	}
}