using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    NavMeshAgent agent;
    [SerializeField] private GameObject respawnPoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.LookAt(player);

        agent.SetDestination(player.position);
    }
    public void Dying()
    {
        GameObject spawnPoint = FindObjectOfType<SpawnPointSelect>().FindFurthestSpawn();
        transform.position = spawnPoint.transform.position;
    }
}
