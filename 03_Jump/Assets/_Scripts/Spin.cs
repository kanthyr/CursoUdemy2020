using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float spinSpeed = 80f;
    public float pushForce = 5f;

    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GameObject.FindWithTag("Player")
            .GetComponent<PlayerController>();
    }
    
    void Update()
    {
        if(!_playerController.GameOver)
        {
            this.transform.localPosition += Vector3.left * (Time.deltaTime * pushForce);
            this.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}
