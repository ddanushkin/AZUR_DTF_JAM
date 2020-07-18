using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.1f;
    
    private void LateUpdate()
    {
        Vector3 dir = target.GetComponent<Rigidbody2D>().velocity;
        Vector3 toMove = new Vector3(target.position.x + (1f * dir.x), target.position.y + (0.5f * dir.y), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, toMove, smoothTime * Time.deltaTime);
    }

}
