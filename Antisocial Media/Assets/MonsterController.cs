using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    NavMeshAgent agent;
    [SerializeField]private float speed = 0.2f;
    [SerializeField] private float speedIncrease = 2.0f;
    [SerializeField] private float speedIncreaseDecrease = 0.33f;
    private float distance;
    [SerializeField] private float howCloseToSlowDown = 0.5f;
    [SerializeField] private LayerMask layerMask;
    public RaycastHit hit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distance = hit.distance + howCloseToSlowDown;
        transform.LookAt(player);

        agent.SetDestination(player.position);

        Physics.Linecast(transform.position,player.position, out hit, layerMask);
        
        if (distance >= 1.0f)
        {
            agent.speed = speed * distance;
        }
        else
        {
            agent.speed = speed;
        }
    }
    public void Dying()
    {
        agent.enabled = false;
        GameObject spawnPoint = FindObjectOfType<SpawnPointSelect>().FindFurthestSpawn();
        transform.position = spawnPoint.transform.position;
        agent.enabled = true;
        speed = speed * (speedIncrease + 1f);
        speedIncrease = speedIncrease * speedIncreaseDecrease;
    }
}
