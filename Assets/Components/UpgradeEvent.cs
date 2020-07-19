namespace Game
{
	internal struct UpgradeEvent
	{
		public Upgrade UpgradeData;

		public UpgradeEvent(Upgrade upgrade)
		{
			UpgradeData = upgrade;
		}
	}
}