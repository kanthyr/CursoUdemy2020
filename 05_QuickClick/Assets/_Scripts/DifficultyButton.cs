using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 2.5f)] private float _difficultySpawnRate = 1f;

    private Button _button;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        _button = this.gameObject.GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    /// <summary>
    /// Cuando se invoca inicia el juego con su nivel de dificultad
    /// </summary>
    void SetDifficulty()
    {
        gameManager.StartGame(_difficultySpawnRate);
    }
}
