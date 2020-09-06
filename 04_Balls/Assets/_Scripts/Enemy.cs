using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveForce;
    
    private Rigidbody _rigidbody;
    private GameObject player;
    private GameObject origin;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        origin = GameObject.Find("Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Vector3 moveDirection = (origin.transform.position - this.transform.position).normalized;
            _rigidbody.AddForce(moveForce * moveDirection);
        }
        else
        {
            Vector3 moveDirection = (player.transform.position - this.transform.position).normalized;
            _rigidbody.AddForce(moveForce * moveDirection);
        }

        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
