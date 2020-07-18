using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	internal class InitSystem : IEcsInitSystem
	{
		private SceneData _sceneData;
		private EcsWorld _ecsWorld;
		
		public void Init()
		{
			var clockEntity = _ecsWorld.NewEntity();
			var clockGo = Object.Instantiate(_sceneData.clockPrefab, Vector3.zero, Quaternion.identity);
			clockEntity.Get<ClockComponent>() = new ClockComponent
			{
				CurrentAngle = 360f,
				MaxAngle = 360f,
				Go = clockGo,
				HandSpeed = 12f,
				ScorePerSecond = 20f,
				SpeedHandBack = 120f,
				HandTransform = clockGo.GetComponent<HandTransformProvider>().handTransform
			};
			
			// for (int i = 0; i < 7; i++)
			// {
				// Object.Instantiate(_sceneData.circle, new Vector3(-4 + (i * 2), 1, 0), Quaternion.identity);
			// }
		}
	}
}