using System.Globalization;
using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public class UpdateScoreUISystem : IEcsRunSystem
	{
		private EcsFilter<UpdateScoreUIEvent> _filter;
		private SceneData _sceneData;
		private GameState _gameState;

		public void Run()
		{
			foreach (var index in _filter)
			{
				_sceneData.UI.Score.text = Mathf.RoundToInt(_gameState.Score).ToString();
				_sceneData.UI.ScorePerSecond.text = _gameState.ScorePerSecond.ToString(CultureInfo.InvariantCulture);
			}
		}
	}
}