using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text gameTimeText;
    public Text penaltyText;
    public Text resultText;
    float res;
    bool gotNewRecord = false;
 
    void Start()
    {
        res = TimeController.time + PenaltyController.hits;
        CheckIfRecordTime();
        SetupResult();
    }

    public void SetupPenaltySeconds(int penalty)
    {
        penaltyText.text = "Penalty: " + penalty.ToString();
    }

    public void SetupLapTime(float time)
    {
        gameTimeText.text = "Time: " + time.ToString("f2").Replace(',', '.');
    }

    public void SetupResult()
    {
        if(gotNewRecord)
        {
            resultText.text = "New Lap Record!: " + res.ToString("f2").Replace(',', '.');
        }
        else
        {
            resultText.text = "Result: " + res.ToString("f2").Replace(',', '.');
        }      
    }
    
    public void CheckIfRecordTime()
    {
        if(Game_manager.manager.currentLevel.level == "Savannah")
        {
            float level1LapTime = (float)Convert.ToDouble(PlayerPrefs.GetString("level1LapTime"), CultureInfo.InvariantCulture.NumberFormat);
            if (res < level1LapTime)
            {
                Debug.Log("New record");
                gotNewRecord = true;
            }
        }
        else if (Game_manager.manager.currentLevel.level == "Mountains")
        {
            float level2LapTime = (float)Convert.ToDouble(PlayerPrefs.GetString("level2LapTime"), CultureInfo.InvariantCulture.NumberFormat);
            if (res < level2LapTime)
            {
                Debug.Log("New record");
                gotNewRecord = true;
            }
        }
        else if (Game_manager.manager.currentLevel.level == "City")
        {
            float level3LapTime = (float)Convert.ToDouble(PlayerPrefs.GetString("level3LapTime"), CultureInfo.InvariantCulture.NumberFormat);
            if (res < level3LapTime)
            {
                Debug.Log("New record");
                gotNewRecord = true;
            }
        }
    }

    public void StorePlayerData()
    {
        FindObjectOfType<PlayerStatistics>().IncreasePlayerData();
        FindObjectOfType<SceneChange>().LoadGame();
    }
}
