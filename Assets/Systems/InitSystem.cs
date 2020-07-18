using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	internal class InitSystem : IEcsInitSystem
	{
		private SceneData _sceneData;
		
		public void Init()
		{
			for (int i = 0; i < 7; i++)
			{
				GameObject.Instantiate(_sceneData.circle, new Vector3(-4 + (i * 2), 1, 0), Quaternion.identity);
			}
		}
	}
}