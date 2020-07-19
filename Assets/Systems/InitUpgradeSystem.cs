using System;
using Game.UnityComponents;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Game
{
	internal class InitUpgradeSystem : IEcsInitSystem
	{
		private EcsWorld _ecsWorld;
		private SceneData _sceneData;
		private Configuration _config;

		public void Init()
		{
			SubscribeUpgradeToButton<HandSpeedUpgrade>("HandSpeed");
			SubscribeUpgradeToButton<ScorePerSecondUpgrade>("ScorePerSecond");
			SubscribeUpgradeToButton<ReloadSpeedUpgrade>("ReloadSpeed");

			SubscribeEntityEventToButton<ClockSpawnEvent>("Spawn Clock");
			SubscribeEntityEventToButton<HelperSpawnEvent>("Spawn Helper");
		}

		private void SubscribeEntityEventToButton<T>(string name) where T : struct
		{
			var buttonGameObject = Object.Instantiate(
				_sceneData.upgradeButtonPrefab, Vector3.zero, quaternion.identity,
				_sceneData.UI.UpgradesLayoutCanvas.transform);

			var buttonComponent = buttonGameObject.GetComponent<Button>();
			buttonGameObject.GetComponentInChildren<Text>().text = name;
			buttonComponent.onClick.AddListener(() =>
			{
				_ecsWorld.NewEntity().Get<T>() = new T();
			});
		}

		private void SubscribeUpgradeToButton<T>(string name) where T : Upgrade
		{
			var upgradeInstanse = (T)Activator.CreateInstance(typeof(T), _config.FindUpgradeConfig(name));
			
			var buttonGameObject = Object.Instantiate(
				_sceneData.upgradeButtonPrefab, Vector3.zero, quaternion.identity,
				_sceneData.UI.UpgradesLayoutCanvas.transform);
			
			var buttonComponent = buttonGameObject.GetComponent<Button>();
			buttonGameObject.GetComponentInChildren<Text>().text = upgradeInstanse.name;
			buttonComponent.onClick.AddListener(() =>
			{
				_ecsWorld.NewEntity().Get<UpgradeEvent>() = new UpgradeEvent(upgradeInstanse);
			});
		}
	}
}