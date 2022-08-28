using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSelection : MonoBehaviour
{
    public GameObject prefab;
    Text obstacleName;
    Text obstaclePenalty;
    Image obstacleImage;

    void Start()
    {
        InstantiateObstacles();
    }

    public void InstantiateObstacles()
    {
        foreach (Obstacle o in Game_manager.manager.obsctacles)
        {
            GameObject option = Instantiate(prefab, transform);


            obstacleName = option.transform.GetChild(0).GetComponent<Text>();
            obstacleName.text = o.obstacle;

            obstaclePenalty = option.transform.GetChild(1).GetComponent<Text>();
            obstaclePenalty.text = o.penalty;

            obstacleImage = option.transform.GetChild(2).GetComponent<Image>();
            obstacleImage.sprite = o.image;
        }
    }
}
