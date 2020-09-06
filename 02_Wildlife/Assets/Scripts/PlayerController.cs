using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xRange = 15f;
    public float speed = 10f;
    public GameObject projectilePrefab;
    
    private float _horizInput;

    void Update()
    {
        // Movimiento del personaje
        _horizInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (Time.deltaTime * speed * _horizInput));

        if (transform.position.x < -xRange)
        {
            // Se sale por la izquierda de la pantalla
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            // Se sale por la derecha de la pantalla
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        //Acciones del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si entramos aqui, hay que lanzar un proyectil
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
