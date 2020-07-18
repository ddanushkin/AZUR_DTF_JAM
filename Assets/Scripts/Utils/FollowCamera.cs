using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform _target;

    public float smoothTime = 0.1f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        _rigidbody2D = _target.GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        Vector3 dir = _rigidbody2D.velocity;
        Vector3 toMove = new Vector3(_target.position.x + (1f * dir.x), _target.position.y + (0.5f * dir.y), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, toMove, smoothTime * Time.deltaTime);
    }

}
