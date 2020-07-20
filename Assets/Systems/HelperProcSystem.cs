using Leopotam.Ecs;

namespace Game
{
	public class HelperProcSystem : IEcsRunSystem
	{
		private EcsFilter<HelperComponent, TimerComponent> _filter;
        
		public void Run()
		{
			foreach (var index in _filter)
			{
				ref TimerComponent timer = ref _filter.Get2(index);
				if (timer.Finished)
				{
					ref EcsEntity helper = ref _filter.GetEntity(index);
					var clockEntity = helper.Get<HelperComponent>().Parent;
					if (clockEntity.Has<ClockReloadEvent>())
					{
						ref ClockReloadEvent reloadEvent = ref clockEntity.Get<ClockReloadEvent>();
						reloadEvent.Timer += 0.1f;
					}
					else
					{
						clockEntity.Get<ClockReloadEvent>() = new ClockReloadEvent()
						{
							Timer = 0.1f
						};	
					}
					timer.Finished = false;
					timer.ElapsedSeconds = -0.1f;
				}
			}
		}
	}
}