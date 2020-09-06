using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // OnTriggerEnter se llamará automáticamente cuando un objeto físico entra dentro del trigger del Game Object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject); // Destruye el objeto asignado al script
            Destroy(other.gameObject); // Destruye el otro objeto
        }
    }
}
