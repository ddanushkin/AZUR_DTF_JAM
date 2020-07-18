using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.1f;

    private Rigidbody2D _targetRB;

    private void Start()
    {
        _targetRB = target.GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        Vector3 dir = _targetRB.velocity;
        Vector3 toMove = new Vector3(target.position.x + (0.8f * dir.x), target.position.y + (0.5f * dir.y), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, toMove, smoothTime * Time.deltaTime);
    }

}
