using System;
using Game;
using Leopotam.Ecs;
using UnityEngine;

class UpdateTimerUISystem : IEcsRunSystem
{
	private SceneData _sceneData;
	
	public void Run()
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
		_sceneData.UI.Timer.text = timeSpan.Seconds.ToString();
	}
}