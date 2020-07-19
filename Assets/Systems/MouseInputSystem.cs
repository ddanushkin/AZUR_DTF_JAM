using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
	public class MouseInputSystem : IEcsRunSystem
	{
		private EcsFilter<ClockComponent> _filter;
		private SceneData _sceneData;
		
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
					if (mouseOverClock && clock.HandSpeed < clock.SpeedHandBack)
					{
						if (clock.HandSpeed < clock.SpeedHandBack)
							_filter.GetEntity(index).Get<ClockReloadEvent>() = new ClockReloadEvent();
					}
				}
			}
		}
	}
}