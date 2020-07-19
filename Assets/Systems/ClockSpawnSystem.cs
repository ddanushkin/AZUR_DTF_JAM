using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public class ClockSpawnSystem : IEcsRunSystem
	{
		private EcsFilter<ClockSpawnEvent> _filter;
		private EcsWorld _ecsWorld;
		private SceneData _sceneData;
		private GameState _gameState;
		
		public void Run()
		{
			if (_filter.IsEmpty()) return;
			var clockEntity = _ecsWorld.NewEntity();
			var clockPosition = new Vector3(0, _gameState.SpawnedClocks * 10f, 0f);
			var clockGo = Object.Instantiate(_sceneData.clockPrefab, clockPosition, Quaternion.identity);
			clockEntity.Get<ClockComponent>() = new ClockComponent
			{
				CurrentAngle = 360f,
				MaxAngle = 360f,
				HandSpeed = 6f,
				ScorePerSecond = 20f,
				SpeedHandBack = 60f,
				HandTransform = clockGo.GetComponent<HandTransformProvider>().handTransform,
				Bounds = clockGo.GetComponent<SpriteBoundProvider>().bounds,
				Transform = clockGo.transform,
				helperCount = 0
			};
			_gameState.SpawnedClocks++;
		}
	}
}