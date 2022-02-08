using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    NavMeshAgent agent;
    RaycastHit hit;
    [SerializeField] private CentrePriority centre;
    [SerializeField] private float speedIncrease = 1.0f;
    [SerializeField] private float speedIncreaseDecrease = 0.66f;
    private float actualSpeedIncrease;

    [SerializeField] private int centreCheckTime = 4;
    [SerializeField] private float centreCheckDist = 4.0f;
    private bool checkingDist = false; 



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        actualSpeedIncrease = speedIncrease + 1.0f;
        centre = FindObjectOfType<CentrePriority>();
    }


    void Update()
    {
        transform.LookAt(player);

        agent.SetDestination(player.position);

        Physics.Linecast(transform.position, player.position, out hit);

        if ((hit.distance > centreCheckDist) && centre.outOfSight && !checkingDist) 
        {
            Debug.Log("checked distance1");
            StartCoroutine(TeleToCentre());
        }
    }

    IEnumerator TeleToCentre()
    {
        checkingDist = true;
        yield return new WaitForSeconds(centreCheckTime);

        if ((hit.distance > centreCheckDist) && centre.outOfSight)
        {
            agent.enabled = false;
            Debug.Log(centre.transform.position);
            transform.position = centre.transform.position;
            agent.enabled = true;
        }
        Debug.Log("checked distance2");
        Debug.Log(hit.distance);
        checkingDist = false;
    }

    public void Dying()
    {
        //disables NavMeshAgent, teleports it to spawn point and enables it again
        agent.enabled = false;
        GameObject spawnPoint = FindObjectOfType<SpawnPointSelect>().FindFurthestSpawn();
        Debug.Log(spawnPoint.transform.position);
        transform.position = spawnPoint.transform.position;
        agent.enabled = true;

        //Decreases % that speed is increased by, and increases speed by that %
        agent.speed = agent.speed * actualSpeedIncrease;
        speedIncrease = speedIncrease * speedIncreaseDecrease;
        actualSpeedIncrease = speedIncrease + 1.0f;
    }



}
