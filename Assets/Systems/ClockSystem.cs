using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
	internal class ClockSystem : IEcsRunSystem
	{
		private EcsFilter<ClockComponent>.Exclude<NeedReloadFlag> _filter;

		public void Run()
		{
			foreach (var index in _filter)
			{
				ref ClockComponent clock = ref _filter.Get1(index);
				var handTransform = clock.HandTransform;
				var angles = handTransform.localEulerAngles;
				
				if (clock.CurrentAngle <= 0)
				{
					clock.CurrentAngle = 0f;
					angles.z = 0f;
					handTransform.eulerAngles = angles;
					_filter.GetEntity(index).Get<NeedReloadFlag>() = new NeedReloadFlag();
				}
        
				if (clock.CurrentAngle > 0f)
				{
					var angleDiff = clock.HandSpeed * Time.deltaTime;
					handTransform.Rotate(Vector3.forward * -angleDiff);
					clock.CurrentAngle -= angleDiff;
					_filter.GetEntity(index).Get<UpdateScoreEvent>() = new UpdateScoreEvent();
				}
			}
			
		}
	}
}