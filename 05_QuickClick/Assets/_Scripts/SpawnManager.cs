using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] targetPrefabs = new GameObject[0];
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTarget", 4f, 1f);
    }

    void SpawnTarget()
    {
        Instantiate(targetPrefabs[Random.Range(0, targetPrefabs.Length)]);
    }
}
