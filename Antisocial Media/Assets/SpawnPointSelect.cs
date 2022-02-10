using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSelect : MonoBehaviour
{
    public List<RespawnPriority> spawnPoints;
    RespawnPriority chosenSpawnPoint;
    private void Start()
    {
        spawnPoints = new List<RespawnPriority>();
        spawnPoints.AddRange(GameObject.FindObjectsOfType<RespawnPriority>());
        Debug.Log(spawnPoints);
    }

    public GameObject FindFurthestSpawn()
    {
        //stores distance of current furthest point
        float currentFurthest = 0f;
        //stores distance of the current selected respawn point
        float currentDistance;
        //loops through each respawnpoint in scene
        foreach(RespawnPriority currentRespawnPoint in spawnPoints)
        {
            //fetches distance of selected point
            currentDistance = Vector3.Distance(currentRespawnPoint.transform.position, FindObjectOfType<MonsterController>().transform.position);
            //if further than currentfurthest select new object
            if (currentDistance > currentFurthest)
            {
                currentFurthest = currentDistance;
                chosenSpawnPoint = currentRespawnPoint;
            }
        }
        //returns the gameobject of furthest spawn point
        Debug.Log(chosenSpawnPoint);
        return chosenSpawnPoint.gameObject;

    }
}
