namespace Game
{
	public class ScorePerSecondUpgrade : Upgrade
	{
		public ScorePerSecondUpgrade(UpgradeConfig config) : base(config) {}

		public override void Process(ref ClockComponent clock)
		{
			clock.ScorePerSecond += level * 0.25f;
			level += 1;
			cost += cost * 0.02f;
		}
	}
}