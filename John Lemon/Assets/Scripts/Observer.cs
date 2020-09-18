using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    private Transform playerTransform = null;
    private GameEnding gameEnding = null;

    private bool isPlayerInRange;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        gameEnding = GameObject.FindObjectOfType<GameEnding>();
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = playerTransform.position - this.transform.position + Vector3.up;
            Ray ray = new Ray(this.transform.position, direction);

            Debug.DrawRay(this.transform.position, direction, Color.magenta, Time.deltaTime, true);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == playerTransform)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == playerTransform)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == playerTransform)
        {
            isPlayerInRange = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 0.1f);
    }
}
