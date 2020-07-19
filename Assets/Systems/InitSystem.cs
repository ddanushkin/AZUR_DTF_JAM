using Leopotam.Ecs;

namespace Game
{
	internal class InitSystem : IEcsInitSystem
	{
		private SceneData _sceneData;
		private EcsWorld _ecsWorld;
		private GameState _gameState;
		
		public void Init()
		{
			var e = _ecsWorld.NewEntity();
			e.Get<ClockSpawnEvent>() = new ClockSpawnEvent();
		}
	}
}