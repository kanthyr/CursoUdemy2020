using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }


    [Header("State of the game")]
    public GameState gameState;

    [Header("Lives context")]
    [SerializeField] private int numberOfLives = 3;
    [SerializeField] private List<GameObject> lives = new List<GameObject>();

    [Header("UI context")]
    [SerializeField] private GameObject titleScreenPanel = null;
    [SerializeField] private GameObject livesPanel = null;
    [SerializeField] private GameObject gameOverPanel = null;
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

    [Header("Prefabs context")]
    [SerializeField] private List<GameObject> targetPrefabs = new List<GameObject>();

    [SerializeField] private float spawnRate = 1f;

    private const string MAX_SCORE = "MAX_SCORE";

    void Start()
    {
        ShowMaxScore();
    }

    /// <summary>
    /// Metodo que inicia la partida cambiando el estado a "inGame", iniciando la corutina "SpawnTarget" e inicializando la puntuacion a cero.
    /// </summary>
    /// <param name="difficultySpawnRate">Cambia el valor de spawnRate por uno nuevo dependiendo la dificultad</param>
    public void StartGame(float difficultySpawnRate)
    {
        this.spawnRate = difficultySpawnRate;
        gameState = GameState.inGame;
        titleScreenPanel.gameObject.SetActive(false);
        livesPanel.gameObject.SetActive(true);
        StartCoroutine("SpawnTarget");
        Score = 0;
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

    /// <summary>
    /// Muestra la puntuación máxima almacenada en PlayerPrefs al iniciar la escena
    /// </summary>
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max score: \n" + maxScore;
    }

    /// <summary>
    /// Al ser invocada guarda la puntuacion si fue más alta que la anterior
    /// </summary>
    public void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (Score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, Score);
        }
    }

    /// <summary>
    /// Cuando se manda a llamar muestra en pantalla "GAME OVER"
    /// </summary>
    public void GameOver()
    {
        Image lifeImage = lives[numberOfLives - 1].gameObject.GetComponent<Image>();
        Color newLifeColor = new Color(lifeImage.color.r, lifeImage.color.g, lifeImage.color.b, lifeImage.color.a / 2);
        lifeImage.color = newLifeColor;

        numberOfLives--;
        
        if (numberOfLives <= 0)
        {
            SetMaxScore();
            gameOverPanel.SetActive(true);
            gameState = GameState.gameOver;
        }
    }

    /// <summary>
    /// Cuando se manda a llamar, se reinicia la escena actual
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
}
