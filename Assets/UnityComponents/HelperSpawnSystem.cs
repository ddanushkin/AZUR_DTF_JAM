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

		public void Run()
		{
			if (_filter.IsEmpty()) return;
			ref ClockComponent clock = ref _clocksFilter.Get1(0);
			//Debug.Log(clock);
			//Debug.Log(clock.Transform);
			var helperPosition = clock.Transform.position;
			var helperEntity = _ecsWorld.NewEntity();
			var go = Object.Instantiate(_sceneData.helperPrefab, helperPosition, Quaternion.identity);
			helperEntity.Get<HelperComponent>() = new HelperComponent
			{
				Angle = 0f,
				Center = helperPosition,
				Radius = 5f,
				RotateSpeed = 0.25f,
				Transform = go.transform
			};
			clock.helperCount++;
		}
	}
}