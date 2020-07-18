using UnityEngine;

namespace Game
{
	internal struct ClockComponent
	{
		public float MaxAngle;
		public float CurrentAngle;
		public float HandSpeed;
		public float ScorePerSecond;
		public GameObject Go;
		public Transform HandTransform;
	}
}