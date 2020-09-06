using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    private float _horizInput;
    
    void Update()
    {
        if (true) // TODO: Cambiar por condicion de game over
        {
            _horizInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, _horizInput * rotationSpeed * Time.deltaTime);
        }
    }
}
