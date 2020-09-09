using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    [SerializeField] private float minForceUp = 12f;
    [SerializeField] private float maxForceUp = 17f;
    [SerializeField] private float minSpinTorque = -10f;
    [SerializeField] private float maxSpinTorque = 10f;
    [SerializeField] private float xMinBorder = -4.5f;
    [SerializeField] private float xMaxBorder = 4.5f;
    
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartLaunch();
    }

    /// <summary>
    /// Manda a llamar las funciones RandomForce(), RandomTorque() y RandomPosition() para añadirle fuerza, torque y posicion al objeto
    /// </summary>
    private void StartLaunch()
    {
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
    }

    /// <summary>
    /// Genera y devuelve un Vector3 con una fuerza ascendente aleatoria entre los valores de minForceUp y maxForceUp
    /// </summary>
    /// <returns>Devuelve un Vector3</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForceUp, maxForceUp);;
    }

    /// <summary>
    /// Genera y devuelve un Vector3 con un torque en los 3 ejes aleatorio entre los valores minSpinTorque y maxSpinTorque
    /// </summary>
    /// <returns>Devuelve un Vector3</returns>
    private Vector3 RandomTorque()
    {
        
        return new Vector3(Random.Range(minSpinTorque, maxSpinTorque), 
            Random.Range(minSpinTorque, maxSpinTorque), 
            Random.Range(minSpinTorque, maxSpinTorque));
    }

    /// <summary>
    /// Genera y devuelve un Vector3 con la posicion en x determinada por los bordes de xMinBorder y xMaxBorder, con una altura de -5 en y
    /// </summary>
    /// <returns>Devuelve un Vector3</returns>
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(xMinBorder, xMaxBorder), -5);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
