using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;
    public List<int> takenSpawnPositions;
    public List<int> blockedPositions;
    public List<int> missingPositions;
    int randomObstacleAmount;
    int first;
    int second;
    int spawnedObstacles = 0;
    
    void Start()
    {
        GetSpawnPointCount();
        
        for (int i = 0; i < first; i++)   
        {
            GetRandomSpawnPointsForFirstListPart();
        }

        for (int i = 0; i < second; i++)       
        {
            GetRandomSpawnPointsForSecondListPart();
        }

        CheckIfObstaclesEnough();
    }

    public void GetSpawnPointCount()
    {
        randomObstacleAmount = Random.Range(10, spawnPoints.Length);
        //Debug.Log("MÄÄRÄ YHTEENSÄ: " + random);

        if (randomObstacleAmount % 2 == 0)
        {
            first = randomObstacleAmount / 2;
        }
        else
        {
            first = Mathf.RoundToInt(randomObstacleAmount / 2);
        }
        second = randomObstacleAmount - first;
    }

    public void CheckIfObstaclesEnough()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!takenSpawnPositions.Contains(i))
            {
                missingPositions.Add(i);
            }
        }
       
        if (spawnedObstacles < 10)
        {
            missingPositions.Reverse();

            int requiredAmount = 10 - spawnedObstacles;
            for(int i = 0; i < requiredAmount; i++)
            {
                int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
                int position = missingPositions[i];
                Transform spawn = spawnPoints[position];
                Instantiate(obstaclePrefabs[randomObstacle], spawn.transform.position, spawn.transform.rotation);
            }     
        }
    }
  
    public void GetRandomSpawnPointsForFirstListPart()
    {
        int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
        int randomPoint = Random.Range(0, first);

        if (takenSpawnPositions.Contains(randomPoint))
        {
            blockedPositions.Add(randomPoint);
            return;
        }
        else
        {
            takenSpawnPositions.Add(randomPoint);
            spawnedObstacles += 1;
        }
        Transform spawn = spawnPoints[randomPoint];
        Instantiate(obstaclePrefabs[randomObstacle], spawn.transform.position, spawn.transform.rotation);
    }

    public void GetRandomSpawnPointsForSecondListPart()
    {
        int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
        int randomPoint = Random.Range(first, spawnPoints.Length);

        if (takenSpawnPositions.Contains(randomPoint))
        {
            blockedPositions.Add(randomPoint);
            return;
        }
        else
        {
            takenSpawnPositions.Add(randomPoint);
            spawnedObstacles += 1;
        }
        Transform spawn = spawnPoints[randomPoint];
        Instantiate(obstaclePrefabs[randomObstacle], spawn.transform.position, spawn.transform.rotation);
    }
}
