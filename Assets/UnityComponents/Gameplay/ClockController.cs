using System;
using UnityEngine;

namespace Game
{
    public class ClockController : MonoBehaviour
    {
        private float _angleReminder;
        private bool _needReload;

        public float defaultAngleReminder;
        public float speed;

        private void Start()
        {
            _angleReminder = defaultAngleReminder;
        }

        void Update()
        {
            Debug.Log($"Angles {transform.eulerAngles}");
            var angles = transform.localEulerAngles;
            if (_angleReminder < 0)
            {
                _angleReminder = 0f;
                angles.z = 0f;
                transform.eulerAngles = angles;
                _needReload = true;
            }
        
            if (_angleReminder > 0f && !_needReload)
            {
                var angleDiff = speed * Time.deltaTime;
                transform.Rotate(Vector3.forward * -angleDiff);
                _angleReminder -= angleDiff;
            }
            
            if (Input.GetMouseButton(0))
            {
                var angleDiff = 120f * Time.deltaTime;
                _angleReminder += angleDiff;
                transform.Rotate(Vector3.forward * angleDiff);
                if (_angleReminder > defaultAngleReminder)
                {
                    angles.z = 0f;
                    transform.eulerAngles = angles;
                    _angleReminder = defaultAngleReminder;
                    _needReload = false;
                }
            }
        }
    }
}
