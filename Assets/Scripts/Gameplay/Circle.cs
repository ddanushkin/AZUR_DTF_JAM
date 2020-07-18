using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Circle : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesCircle = new Sprite[7];
    private float _degrees = 0f;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spritesCircle[Random.Range(0, 7)];
    }

    private void Update()
   {
        transform.eulerAngles = Vector3.forward * _degrees;
        _degrees += 50 * Time.deltaTime;
   }
}
