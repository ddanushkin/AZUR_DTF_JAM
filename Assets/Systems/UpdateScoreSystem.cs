using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	internal class UpdateScoreSystem : IEcsRunSystem
	{
		private EcsFilter<ClockComponent, UpdateScoreEvent> _filter;
		private GameState _gameState;
		private EcsWorld _ecsWorld;
		
		public void Run()
		{
			foreach (var index in _filter)
			{
				ref ClockComponent clock = ref _filter.Get1(index);
				float truScoreCurrent = clock.ScorePerSecond * clock.HandSpeed / 6f;
				var scoreDiff = clock.ScorePerSecond * clock.HandSpeed / 6f * Time.deltaTime;
				_gameState.Score += scoreDiff;
				_gameState.ScorePerSecond = truScoreCurrent;
			}
			_ecsWorld.NewEntity().Get<UpdateScoreUIEvent>();
		}
	}
}