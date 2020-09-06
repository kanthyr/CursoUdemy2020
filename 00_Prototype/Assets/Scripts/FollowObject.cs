using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    
    void FixedUpdate()
    {
        //this.transform.position = target.transform.position + offset;
        this.transform.LookAt(target.transform);
    }
}
