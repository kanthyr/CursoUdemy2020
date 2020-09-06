using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveForce;
    
    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpDuration;
    public GameObject[] powerUpIndicators;
    
    private float _vertInput;
    private Rigidbody _rigidbody;
    private GameObject origin;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        origin = GameObject.Find("Origin");
    }

    void Update()
    {
        MovePlayer();

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position;
        }
        powerUpIndicators[0].gameObject.transform.Rotate(Vector3.up, 3f);
        powerUpIndicators[1].gameObject.transform.Rotate(Vector3.up, -1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp") && !hasPowerUp)
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            foreach (GameObject indicator in powerUpIndicators)
            {
                indicator.gameObject.SetActive(true);
            }
            StartCoroutine("PowerUpCountdown");
        }

        if (other.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
            StartCoroutine("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * powerUpForce,ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Detecta el Input Vertical para realizar el movimiento
    /// del jugador hacia adelante y hacia atrás de acuerdo al
    /// eje Z de origen.
    /// </summary>
    private void MovePlayer()
    {
        _vertInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(origin.transform.forward * (moveForce * _vertInput), ForceMode.Force);
    }

    IEnumerator PowerUpCountdown()
    {
        powerUpForce *= 2;
        yield return new WaitForSeconds(powerUpDuration/2);
        powerUpIndicators[1].gameObject.SetActive(false);
        powerUpForce /= 2;
        yield return new WaitForSeconds(powerUpDuration/2);
        powerUpIndicators[0].gameObject.SetActive(false);
        hasPowerUp = false;
    }

    IEnumerator GameOver()
    {
        Debug.Log("GAME OVER");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Prototype 4");
    }
}
