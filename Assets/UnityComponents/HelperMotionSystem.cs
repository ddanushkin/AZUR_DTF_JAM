using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public class HelperMotionSystem : IEcsRunSystem
	{
		private EcsFilter<HelperComponent> _filter;
		
		public void Run()
		{
			foreach (var index in _filter)
			{
				ref HelperComponent helper = ref _filter.Get1(index);
				helper.Angle -= helper.RotateSpeed * Time.deltaTime;
				var offset = new Vector3(Mathf.Sin(helper.Angle), Mathf.Cos(helper.Angle), 0) * helper.Radius;
				helper.Transform.position = helper.Center + offset;
			}
		}
	}

	public struct HelperComponent
	{
		public Vector3 Center;
		public float Radius;
		public float Angle;
		public Transform Transform;
		public float RotateSpeed;
		public EcsEntity Parent;
	}
}