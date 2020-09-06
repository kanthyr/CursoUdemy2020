using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.FindWithTag("Player")
            .GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_playerController.GameOver)
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}
