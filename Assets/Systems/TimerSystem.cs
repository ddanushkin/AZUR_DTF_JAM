using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public class TimerSystem : IEcsRunSystem
	{
		private EcsFilter<TimerComponent> _filter;

		public void Run()
		{
			foreach (var index in _filter)
			{
				if (_filter.Get1(index).Finished) return;
				ref TimerComponent timer = ref _filter.Get1(index);
				timer.ElapsedSeconds += Time.deltaTime;
				if (timer.ElapsedSeconds >= timer.TotalSeconds)
					timer.Finished = true;
			}
		}
	}
}