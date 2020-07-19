using System;
using System.Globalization;
using Game;
using Leopotam.Ecs;
using UnityEngine;

class UpdateTimerUISystem : IEcsRunSystem
{
	private SceneData _sceneData;
	private GameState _gameState;
	
	public void Run()
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
		_sceneData.UI.Timer.text = timeSpan.Seconds.ToString();
		_sceneData.UI.ScorePerSecond.text = _gameState.ScorePerSecond.ToString(CultureInfo.InvariantCulture);
		_gameState.ScorePerSecond = 0f;

	}
}