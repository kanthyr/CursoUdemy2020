using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float displayFadeDuration = 1f;
    [SerializeField] private GameObject player = null;
    [SerializeField] private CanvasGroup exitBackGroundImageCanvasGroup = null;
    [SerializeField] private CanvasGroup caughtBackGroundImageCanvasGroup = null;
    [SerializeField] private AudioSource exitAudio = null;
    [SerializeField] private AudioSource caughtAudio = null;

    private bool hasAudioPlayed;

    private float timer;

    private bool isPlayerAtExit;
    private bool isPlayerCaught;

    private void Update()
    {
        if(isPlayerAtExit)
        {
            EndLevel(exitBackGroundImageCanvasGroup, false, exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackGroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    /// <summary>
    /// Al invocarse muestra la imagen de fin de la partida y cierra el juego
    /// </summary>
    /// <param name="imageCanvasGroup">Imagen de fin de partida correspondiente</param>
    /// <param name="doRestart"></param>
    /// <param name="audioSource"></param>
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);

        if (timer > fadeDuration + displayFadeDuration)
        {
            if(doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
}
