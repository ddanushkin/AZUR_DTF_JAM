using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public class HelperSpawnSystem : IEcsRunSystem
	{
		private EcsFilter<HelperSpawnEvent> _filter;
		private EcsFilter<ClockComponent> _clocksFilter;
		private EcsWorld _ecsWorld;
		private SceneData _sceneData;
		private GameState _gameState;

		public void Run()
		{
			if (_filter.IsEmpty()) return;
			EcsEntity clockEntity = _gameState.ActiveClock;
			ref ClockComponent clock = ref clockEntity.Get<ClockComponent>();
			clock.helperCount++;
			var helperPosition = clock.Transform.position;
			var helperEntity = _ecsWorld.NewEntity();
			var go = Object.Instantiate(
				_sceneData.helperPrefab, helperPosition, Quaternion.identity, clock.Transform);
			helperEntity.Get<HelperComponent>() = new HelperComponent
			{
				Angle = 0f,
				Center = helperPosition,
				Radius = 5f,
				RotateSpeed = 0.25f,
				Transform = go.transform,
				Parent = clockEntity
			};
			helperEntity.Get<TimerComponent>() = new TimerComponent()
			{
				ElapsedSeconds = 0f,
				Finished = false,
				TotalSeconds = 5f
			};
		}
	}
}