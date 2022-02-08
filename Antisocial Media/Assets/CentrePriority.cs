using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrePriority : MonoBehaviour
{
    public bool outOfSight = true;
    RaycastHit hit;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        outOfSight = Physics.Linecast(transform.position, player.position, layerMask);
    }

    public bool Distance()
    {
        return outOfSight;
    }
}
