using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	internal class UpdateScoreSystem : IEcsRunSystem
	{
		private EcsFilter<ClockComponent, UpdateScoreEvent> _filter;
		private SceneData _sceneData;
		private GameState _gameState;
		
		public void Run()
		{
			foreach (var index in _filter)
			{
				ref ClockComponent clock = ref _filter.Get1(index);
				var scoreDiff = clock.ScorePerSecond * clock.HandSpeed / 6f * Time.deltaTime;
				_gameState.Score += scoreDiff;
				_sceneData.UI.Score.text = Mathf.RoundToInt(_gameState.Score).ToString();
			}
		}
	}
}