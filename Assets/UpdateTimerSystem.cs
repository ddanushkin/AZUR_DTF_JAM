using System;
using Leopotam.Ecs;
using UnityEngine;

class UpdateTimerSystem : IEcsRunSystem
{
	private UI _ui;
	
	public void Run()
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
		_ui.Timer.text = timeSpan.Seconds.ToString();
	}
}