using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
	public class ClockReloadSystem : IEcsRunSystem
	{
		private EcsFilter<ClockComponent, ClockReloadEvent> _filter;
		
		public void Run()
		{
			foreach (var index in _filter)
			{
				ref ClockComponent clock = ref _filter.Get1(index);
				var handTransform = clock.HandTransform;
				var angles = handTransform.localEulerAngles;
				
				var angleDiff = clock.SpeedHandBack * Time.deltaTime;
				clock.CurrentAngle += angleDiff;
				handTransform.Rotate(Vector3.forward * angleDiff);
				if (clock.CurrentAngle >= clock.MaxAngle)
				{
					angles.z = 0f;
					handTransform.eulerAngles = angles;
					clock.CurrentAngle = clock.MaxAngle;
				}
			}
		}
	}
}