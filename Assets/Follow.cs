using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject followBy;
    private Rigidbody2D _rb;
    private Transform _transform;
    private Vector3 vel;
    public float smooth = 0.5f;
    void Start()
    {
        vel = Vector3.zero;
        _rb = followBy.GetComponent<Rigidbody2D>();
        _transform = followBy.transform;
    }
    
    void Update()
    {
        var camPos = transform.position;
        var objPos = _transform.position;
        objPos.z = camPos.z;
        var dir = Mathf.Sign(_rb.velocity.x);
        var nextPos = objPos + new Vector3(dir * 1.1f, 0f, 0f);
        // transform.position = Vector3.SmoothDamp(camPos, nextPos, ref vel, 0.01f);
        transform.position = Vector3.MoveTowards(camPos, nextPos, smooth * Time.deltaTime);
    }
}
