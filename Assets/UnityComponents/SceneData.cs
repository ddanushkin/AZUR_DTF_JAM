using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

namespace Game
{
	class SceneData : MonoBehaviour
	{
		public UI UI;
		public GameObject circle;
		public GameObject clockPrefab;
		public GameObject helperPrefab;
		public GameObject upgradeButtonPrefab;
		public Camera camera;
		private void Awake()
		{
			camera = Camera.main;
		}
	}
}