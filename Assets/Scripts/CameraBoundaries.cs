using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x >= 15.4)
        {
            transform.position = new Vector2(15.4f, transform.position.y);
        }

        else if (transform.position.x <= -0.04)
        {
            transform.position = new Vector2(-0.04f, transform.position.y);
        }

        if (transform.position.y >= 7.7)
        {
            transform.position = new Vector2(transform.position.x, 7.7f);
        }

        else if (transform.position.y <= -0.01)
        {
            transform.position = new Vector2(transform.position.x, -0.01f);

        }
    }
}
