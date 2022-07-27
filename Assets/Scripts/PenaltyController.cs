using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyController : MonoBehaviour
{
    public static int hits = 0;
    public Text hitsCounter;
    
    void Start()
    {
        hitsCounter.text = "Penalty seconds: " + hits.ToString();
    }

    public void AddHit(int hit)
    {
        string result;

        result = (hits += hit).ToString();
        //Debug.Log(result);
        hitsCounter.text = "Penalty seconds: " + result.ToString();
    }

    public void GameOver()
    {
        FindObjectOfType<GameOverMenu>().SetupPenaltySeconds(hits);
    }
}
