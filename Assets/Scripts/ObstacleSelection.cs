using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSelection : MonoBehaviour
{
    public GameObject prefab;
    public Text obstacleName;
    public Text obstaclePenalty;
    public Image obstacleImage;

    void Start()
    {
        InstantiateLevels();
    }

    public void InstantiateLevels()
    {
        foreach (Obstacle o in Game_manager.manager.obsctacles)
        {
            GameObject option = Instantiate(prefab, transform);


            obstacleName = option.transform.GetChild(0).GetComponent<Text>();
            obstacleName.text = o.obstacle;

            obstacleName = option.transform.GetChild(1).GetComponent<Text>();
            obstacleName.text = o.penalty;

            obstacleImage = option.transform.GetChild(2).GetComponent<Image>();
            obstacleImage.sprite = o.image;
        }
    }
}
