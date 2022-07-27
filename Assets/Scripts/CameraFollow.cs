using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        player = Instantiate(Game_manager.manager.currentCar.car, transform.position, Quaternion.identity);
        
        offset = new Vector3(0f, 0f, -1f);
    }

    void Update()
    {
		if(player) {
			transform.position = player.transform.position + offset;
		}
    }
}
