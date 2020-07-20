using Game.UnityComponents;
using UnityEngine.UI;

namespace Game
{
	public class ScorePerSecondUpgrade : Upgrade
	{
		public static ScorePerSecondUpgrade Instance;

		public ScorePerSecondUpgrade(UpgradeConfig config, Button button) : base(config, button)
		{
			Instance = this;
		}

		public override void Process(ref ClockComponent clock)
		{
			clock.ScorePerSecond += level * 0.25f;
			level += 1;
			cost += cost * 0.02f;
		}
	}
}