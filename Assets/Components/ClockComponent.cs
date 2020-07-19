using UnityEngine;

namespace Game
{
	public struct ClockComponent
	{
		public float MaxAngle;
		public float CurrentAngle;
		public float HandSpeed;
		public float ScorePerSecond;
		public float SpeedHandBack;
		public GameObject Go;
		public Transform HandTransform;
	}
}