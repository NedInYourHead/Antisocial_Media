using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    NavMeshAgent agent;
    private float speed = 0.2f;
    [SerializeField] private float speedIncrease = 2.0f;
    [SerializeField] private float speedIncreaseDecrease = 0.33f;
    [SerializeField] private LayerMask layerMask;
    RaycastHit hit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.LookAt(player);

        agent.SetDestination(player.position);

        Physics.Linecast(transform.position,player.position, out hit, layerMask);
        
        if (hit.distance >= 1.0f)
        {
            agent.speed = speed * hit.distance;
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
        Debug.Log(spawnPoint.transform.position);
        transform.position = spawnPoint.transform.position;
        agent.enabled = true;
        speed = speed * speedIncrease;
        speedIncrease = speedIncrease - speedIncreaseDecrease;
    }
}
