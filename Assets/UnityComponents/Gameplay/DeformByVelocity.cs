using UnityEngine;

namespace Game
{
	class DeformByVelocity : MonoBehaviour
	{
		private Rigidbody2D _rb;
		private Vector3 _minLocalScale;
		private Vector3 _defaultScale;
	
		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			_defaultScale = transform.localScale;
			_minLocalScale = new Vector3(_defaultScale.x, _defaultScale.y * 0.5f);
		}

		private void Update()
		{
			var scale = transform.localScale;
			transform.localScale = Vector3.MoveTowards(scale,
				_defaultScale + new Vector3(-Mathf.Abs(_rb.velocity.x * 2f), -Mathf.Abs(_rb.velocity.y * 2f)), 0.15f);
			if (transform.localScale.y < _minLocalScale.y)
				transform.localScale = new Vector3(scale.x, _minLocalScale.y);
		}
	}
}