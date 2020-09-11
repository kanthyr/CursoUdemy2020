using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private int score;

    private int Score
    {
        set
        {
            score = (int) Mathf.Clamp(value, 0f, 99999f);
        }
        get
        {
            return score;
        }
    }
    
    [SerializeField] private List<GameObject> targetPrefabs = new List<GameObject>();

    [SerializeField] private float spawnRate = 1f;

    void Start()
    {
        StartCoroutine("SpawnTarget");
        UpdateScore(0);
    }

    /// <summary>
    /// Actualiza la puntuacion y lo muestra en pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuacion del jugador</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = ("Score\n" + Score);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
}
