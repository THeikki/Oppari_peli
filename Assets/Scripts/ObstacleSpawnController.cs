using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;
    public List<int> takenSpawnPositions;
    public List<int> blockedValues;
    public List<int> missingValues;
    int random;
    int first;
    int second;
    int total = 0;
    
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
        random = Random.Range(10, spawnPoints.Length);
        //Debug.Log("MÄÄRÄ YHTEENSÄ: " + random);

        if (random % 2 == 0)
        {
            first = random / 2;
        }
        else
        {
            first = Mathf.RoundToInt(random / 2);
        }
        second = random - first;
    }

    public void CheckIfObstaclesEnough()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!takenSpawnPositions.Contains(i))
            {
                missingValues.Add(i);
            }
        }
       
        if (total < 10)
        {
            missingValues.Reverse();

            int i = 10 - total;
            for(int x = 0; x < i; x++)
            {
                int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
                int r = missingValues[x];
                Transform spawn = spawnPoints[r];
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
            blockedValues.Add(randomPoint);
            return;
        }
        else
        {
            takenSpawnPositions.Add(randomPoint);
            total += 1;
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
            blockedValues.Add(randomPoint);
            return;
        }
        else
        {
            takenSpawnPositions.Add(randomPoint);
            total += 1;
        }
        Transform spawn = spawnPoints[randomPoint];
        Instantiate(obstaclePrefabs[randomObstacle], spawn.transform.position, spawn.transform.rotation);
    }
}
