using Leopotam.Ecs;

namespace Game
{
	internal class InitSystem : IEcsInitSystem
	{
		private SceneData _sceneData;
		private EcsWorld _ecsWorld;
		
		public void Init()
		{
			var Starter = _ecsWorld.NewEntity();
			Starter.Get<ClockSpawnEvent>() = new ClockSpawnEvent();
			Starter.Get<HelperSpawnEvent>() = new HelperSpawnEvent(); 
		}
	}
}