using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
	internal class InitUpgradeSystem : IEcsInitSystem
	{
		private EcsWorld _ecsWorld;
		private SceneData _sceneData;
		private Configuration _config;

		public void Init()
		{
			SubscribeUpgradeToButtonEvent(
				_sceneData.UI.HandSpeedUpgradeButton,
				new HardSpeedUpgrade(_config.FindUpgradeConfig("HandSpeed")));
			
			SubscribeUpgradeToButtonEvent(
				_sceneData.UI.ScoreUpgradeButton,
				new ScorePerSecondUpgrade(_config.FindUpgradeConfig("ScorePerSecond")));
			
			SubscribeUpgradeToButtonEvent(
				_sceneData.UI.HandReloadSpeedButton,
				new ReloadSpeedUpgrade(_config.FindUpgradeConfig("ReloadSpeed")));
		}

		private void SubscribeUpgradeToButtonEvent(Button button, Upgrade upgrade)
		{
			button.onClick.AddListener(() =>
			{
				_ecsWorld.NewEntity().Get<UpgradeEvent>() = new UpgradeEvent(upgrade);
			});
		}
	}
}