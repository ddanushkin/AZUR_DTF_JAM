using System;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private float _direction = 1f;
        private float _speed = 4f;
        private bool _isJump;
        private Ray2D _ray2D;
        private BoxCollider2D _collider;

        // Start is called before the first frame update
        void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = new Vector2(_speed * _direction, _rb.velocity.y);
            _direction = 1f;
        }
    
        private void Update()
        {    
            if (Input.GetButton("Jump"))
            {   
                Bounds bounds = _collider.bounds;
                Vector2 rayOrigin = new Vector2(bounds.center.x, bounds.center.y - (bounds.size.y * 0.5f + 0.01f));
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down);
                if (hit && hit.collider.CompareTag("RoomFloor") && hit.distance < 0.01f && !_isJump)
                {
                    Debug.DrawRay(rayOrigin, Vector2.down, Color.magenta, 0.25f);
                    _isJump = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_isJump)
            {
                _rb.AddForce(Vector2.up * 6.5f, ForceMode2D.Impulse);
                _isJump = false;
                Debug.DrawRay(transform.position, _rb.velocity, Color.green, 0.25f);
            }
        }
    }
}