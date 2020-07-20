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
		private const string PrefixHandSpeedUpgrade = "Upgrade hand speed: ";
		private const string PrefixHandSpeedBonus = "Bonus speed: ";
		private const string PrefixScoreUpgrade = "Upgrade score per second: ";

		public void Run()
		{
			foreach (var index in _filter)
			{
				_sceneData.UI.Score.text = "Score: " + Mathf.RoundToInt(_gameState.Score);
			}
		}
	}
}