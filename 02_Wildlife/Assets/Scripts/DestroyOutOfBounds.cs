using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 25f;
    public float bottomBound = -10f;
    
    void Update()
    {
        if (this.transform.position.z > topBound)
            Destroy(this.gameObject);
        
        if (this.transform.position.z < bottomBound)
        {
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }
}
