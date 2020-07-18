using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameBuilder : MonoBehaviour
{
    [SerializeField] private GameObject prefabStartRoom;
    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] private GameObject[] prefabsFloors = new GameObject[3];

    private void Awake()
    {
        Instantiate(prefabPlayer, Vector3.zero, Quaternion.identity);
    }

    void Start()
    {
        Instantiate(prefabStartRoom, new Vector3(0, 0, 0), Quaternion.identity);
        
        for (int i = 1; i < 5; i++)
        {
            Instantiate(prefabsFloors[Random.Range(0, 3)], new Vector3(0, i * 2, 0), Quaternion.identity);
        }
    }
}
