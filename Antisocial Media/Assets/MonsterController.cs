using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    NavMeshAgent agent;
    [SerializeField] private float speedIncrease = 2.0f;
    [SerializeField] private float speedIncreaseDecrease = 0.33f;

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
        agent.enabled = false;
        GameObject spawnPoint = FindObjectOfType<SpawnPointSelect>().FindFurthestSpawn();
        Debug.Log(spawnPoint.transform.position);
        transform.position = spawnPoint.transform.position;
        agent.speed = agent.speed * speedIncrease;
        agent.enabled = true;
        speedIncrease = speedIncrease * speedIncreaseDecrease;
    }
}
