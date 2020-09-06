using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    
    private int animalIndex;
    private float spawnRangeX = 14f;
    private float spawnPosZ;

    [SerializeField, Range(2, 5), Tooltip("Ajusta el tiempo para comenzar a aparecer los enemigos")]
    private float startDelay = 2f;
    [SerializeField, Range(0.1f, 3f), Tooltip("Ajusta el tiempo entre aparicion de enemigos")]
    private float spawnInterval = 1.5f;
    
    private void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        // Generar la posicion en donde va a aparecer el proximo enemigo
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);
        animalIndex = Random.Range(0, enemies.Count);
        Instantiate(enemies[animalIndex],
            spawnPos,
            enemies[animalIndex].transform.rotation);
    }
    
}
