using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyController : MonoBehaviour
{
    public static int penaltySeconds = 0;
    public Text penaltyCounter;
    
    void Start()
    {
        penaltyCounter.text = "Penalty seconds: " + penaltySeconds.ToString();
    }

    public void AddHit(int penalty)
    {
        string result;

        result = (penaltySeconds += penalty).ToString();
        //Debug.Log(result);
        penaltyCounter.text = "Penalty seconds: " + result.ToString();
    }
}
