using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private TrailRenderer _trailRenderer;
    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        if (Input.GetButton("Fire1"))
        {
            _trailRenderer.enabled = true;
        }
        else
        {
            _trailRenderer.enabled = false;
        }
    }
}
