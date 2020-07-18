using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
	internal class UiUpgradeSystem : IEcsInitSystem
	{
		private EcsWorld _ecsWorld;
		private SceneData _sceneData;
		private GameState _gameState;
		
		public void Init()
		{
			Button handUpgradeButton = _sceneData.UI.HandSpeedUpgradeButton;
			handUpgradeButton.onClick.RemoveAllListeners();
			handUpgradeButton.onClick.AddListener(() =>
			{
				_ecsWorld.NewEntity().Get<HandSpeedUpgradeEvent>();
			});
		}
	}
}