using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDeform : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _direction = 1f;
    private Vector3 _defaultScale;
    private float _speed = 4f;
    private float _maxSpeed = 4f;
    private bool canJump = false;
    private Vector3 _minLocalScale;
    private Ray2D _ray2D;
    private BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(_speed * _direction, _rb.velocity.y);
        _defaultScale = transform.localScale;
        _direction = 1f;
        _minLocalScale = new Vector3(_defaultScale.x, _defaultScale.y * 0.5f);
    }
    
    private void Update()
    {
        if (Input.GetButton("Jump") && canJump)
        {
            canJump = false;
            _rb.AddForce(Vector2.up * 2.5f, ForceMode2D.Impulse);
        }

        transform.localScale = Vector3.MoveTowards(transform.localScale,
            _defaultScale + new Vector3(-Mathf.Abs(_rb.velocity.x * 2f), -Mathf.Abs(_rb.velocity.y * 2f)), 0.15f);
        
        Bounds bounds = _collider.bounds;
        Vector2 rayOrigin = new Vector2(bounds.center.x, bounds.center.y - (bounds.size.y * 0.5f + 0.01f));
        RaycastHit2D _hit = Physics2D.Raycast(rayOrigin, Vector2.down);
        if (_hit && _hit.distance < 0.1f)
            canJump = true;
        Debug.DrawRay(rayOrigin, Vector2.down, Color.magenta);
    }
}
