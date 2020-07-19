using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	internal class UpgradeEventSystem : IEcsRunSystem
	{
		private GameState _gameState;
		private EcsFilter<UpgradeEvent> _eventFilter;
		private EcsFilter<ClockComponent> _filter;
		private EcsWorld _ecsWorld;
		
		public void Run()
		{
			if (_eventFilter.IsEmpty()) return;
				ref Upgrade upgrade = ref _eventFilter.Get1(0).UpgradeData;
			if (_gameState.Score < upgrade.cost) return;
			_gameState.Score -= upgrade.cost;
			foreach (var index in _filter)
			{
				ref ClockComponent clockComponent = ref _filter.Get1(index);
				upgrade.Process(ref clockComponent);
			}
			
			_ecsWorld.NewEntity().Get<UpdateScoreUIEvent>();
		}
	}
}