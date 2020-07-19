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
		private GameState _gameState;
		
		public void Init()
		{
			SubscribeUpgradeToButton<HandSpeedUpgrade>("Increase Hand Speed: ");
			SubscribeUpgradeToButton<ScorePerSecondUpgrade>("ScorePerSecond");
			SubscribeUpgradeToButton<ReloadSpeedUpgrade>("Reload Speed: ");

			SubscribeEntityEventToButton<ClockSpawnEvent>("Spawn Clock");
			//SubscribeEntityEventToButton<HelperSpawnEvent>("Spawn Helper");
			
			var buttonGameObject = Object.Instantiate(
				_sceneData.upgradeButtonPrefab, Vector3.zero, quaternion.identity,
				_sceneData.UI.UpgradesLayoutCanvas.transform);

			var buttonComponent = buttonGameObject.GetComponent<Button>();
			buttonGameObject.GetComponentInChildren<Text>().text = "Spawn Helper";
			buttonComponent.onClick.AddListener(() =>
			{
				_ecsWorld.NewEntity().Get<HelperSpawnEvent>() = new HelperSpawnEvent()
				{
					Parent = _gameState.ActiveClock
				};
			});
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
			upgradeInstanse.button = buttonComponent;
			buttonComponent.onClick.AddListener(() =>
			{
				_ecsWorld.NewEntity().Get<UpgradeEvent>() = new UpgradeEvent(upgradeInstanse);
			});
		}
	}
}