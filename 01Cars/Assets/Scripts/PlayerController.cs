using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Propiedades o variables, o campos
    [SerializeField, Tooltip("")]
    private bool carMode;
    [SerializeField, Tooltip("")]
    private bool planeMode;
    
    [Range(0, 120), SerializeField, Tooltip("Velocidad lineal máxima del coche")]
    private float speed = 5.0f;
    [Range(0, 90), SerializeField, Tooltip("Velocidad de giro máxima del coche")]
    private float turnspeed = 35f;

    private float horizontalInput;

    private float verticalInput;
    
    
    
    void Update()
    {

        if (carMode)
        {
            planeMode = false;
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            // S = S0 + V * t * (direccion)
            transform.Translate(Vector3.forward * (speed * Time.deltaTime * verticalInput));
            transform.Rotate(Vector3.up * (turnspeed * Time.deltaTime * horizontalInput));
        }
        if (planeMode)
        {
            carMode = false;
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            // S = S0 + V * t * (direccion)
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            transform.Rotate(Vector3.right * (turnspeed * Time.deltaTime * verticalInput));
            transform.Rotate(Vector3.up * (turnspeed * Time.deltaTime * horizontalInput));
        }
    }
}
