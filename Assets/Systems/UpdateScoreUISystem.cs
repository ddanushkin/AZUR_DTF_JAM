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
				_sceneData.UI.Score.text = Mathf.RoundToInt(_gameState.Score).ToString();
				_sceneData.UI.ScorePerSecond.text = _gameState.ScorePerSecond.ToString(CultureInfo.InvariantCulture);
				// _sceneData.UI.costHandSpeedUpgrade.text = PrefixHandSpeedUpgrade +
				//                                           Mathf.Round(HandSpeedUpgrade.Instance.cost).ToString(CultureInfo.
				// 	                                          InvariantCulture);
				// _sceneData.UI.costScoreUpgrade.text = PrefixScoreUpgrade +
				//                                       Mathf.Round(ScorePerSecondUpgrade.Instance.cost).ToString(CultureInfo
				// 	                                      .InvariantCulture);
				// _sceneData.UI.handSpeedBonus.text = PrefixHandSpeedBonus +
				//                                     HandSpeedUpgrade.Instance.BonusSpeed.ToString(CultureInfo
				// 	                                    .InvariantCulture);
			}
		}
	}
}