using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float counter = 0;
    private float nextWaitTime = 2;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter > nextWaitTime)
            {
                counter = 0;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
    }
}
