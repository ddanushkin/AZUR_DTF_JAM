using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	internal class HandSpeedUpgradeSystem : IEcsRunSystem
	{
		private GameState _gameState;
		private EcsFilter<HandSpeedUpgradeEvent> _eventFilter;
		private EcsFilter<ClockComponent> _filter;
		public void Run()
		{
			if (_gameState.Score < 100f || _eventFilter.IsEmpty()) return;
			_gameState.Score -= 100f;
			foreach (var index in _filter)
			{
				ref ClockComponent clock = ref _filter.Get1(index);
				clock.HandSpeed += _gameState.handSpeedUpgradeLvl * 2f;
				_gameState.handSpeedUpgradeLvl += 1;
			}
		}
	}
}