using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 3, -6);

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
