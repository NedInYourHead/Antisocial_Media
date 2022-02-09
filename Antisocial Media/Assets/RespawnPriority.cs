using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPriority : MonoBehaviour
{
    private float priority = 0.0f;
    RaycastHit hit;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (Physics.Linecast(transform.position, player.position, out hit, layerMask))
        {
            priority = (hit.distance * -1);
        }

    }

    public float Distance()
    {
        return priority;
    }
}
