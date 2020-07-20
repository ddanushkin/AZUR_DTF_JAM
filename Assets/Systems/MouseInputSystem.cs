using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
	public class MouseInputSystem : IEcsRunSystem
	{
		private EcsFilter<ClockComponent> _filter;
		private SceneData _sceneData;
		private GameState _gameState;
		
		public void Run()
		{
			if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
			{
				var mousePosition = _sceneData.camera.ScreenToWorldPoint(Input.mousePosition);
				foreach (var index in _filter)
				{
					var clock = _filter.Get1(index);
					mousePosition.z = clock.Bounds.center.z;
					var mouseOverClock = clock.Bounds.Contains(mousePosition);
					clock.Transform.GetComponent<SetState>().Set(false);
					if (mouseOverClock && clock.HandSpeed < clock.SpeedHandBack)
					{
						clock.Transform.GetComponent<SetState>().Set(true);
						_gameState.ActiveClock = _filter.GetEntity(index);
						if (clock.HandSpeed < clock.SpeedHandBack)
						{
							var clockEntity = _filter.GetEntity(index);
							if (clockEntity.Has<ClockReloadEvent>())
							{
								ref ClockReloadEvent reloadEvent = ref clockEntity.Get<ClockReloadEvent>();
								reloadEvent.Timer += 0.001f;
							}
							else
							{
								_filter.GetEntity(index).Get<ClockReloadEvent>() = new ClockReloadEvent()
								{
									Timer = 0.001f
								};	
							}
						}
					}
				}
			}
		}
	}
}