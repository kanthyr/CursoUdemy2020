using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float jumpForce = 10;
    public float gravityMultiplier;

    public ParticleSystem explosion;
    public ParticleSystem dirtTrail;

    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip crashSound;

    private AudioSource _audioSource;
    
    private Rigidbody _playerRb;
    private bool isGrounded = true;
    
    private bool _gameOver;
    private Animator _animator;

    private const string SPEED_F = "Speed_f";
    private float speed = 1f;
    private const string JUMP_TRIG = "Jump_trig";
    private const string GROUNDED = "Grounded";
    private const string DEATH_B = "Death_b";
    private const string DEATHTYPE_INT = "DeathType_int";

    public bool GameOver => _gameOver;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = this.GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        _animator = this.GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, speed);
        _audioSource = this.GetComponent<AudioSource>();
        dirtTrail.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !GameOver)
        {
            dirtTrail.Stop();
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // F = m*a
            isGrounded = false;
            _animator.SetTrigger(JUMP_TRIG);
            _animator.SetBool(GROUNDED, isGrounded);
            _audioSource.PlayOneShot(jumpSound, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !GameOver)
        {
            isGrounded = true;
            _animator.SetBool(GROUNDED, isGrounded);
            dirtTrail.Play();
            _audioSource.PlayOneShot(landSound, 0.5f);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            dirtTrail.Stop();
            explosion.Play();
            _animator.SetInteger(DEATHTYPE_INT, Random.Range(1, 3));
            _animator.SetBool(DEATH_B, true);
            _audioSource.PlayOneShot(crashSound, 0.5f);
            Debug.Log("GAME OVER");
            Invoke("RestartGame", 3f);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }
    
}
