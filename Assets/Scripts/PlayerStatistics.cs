using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    float res;

    void Start()
    {
        res = TimeController.time + PenaltyController.penaltySeconds;
    }
   
    public void IncreaseGameTimes()
    {
        if (Game_manager.manager.currentLevel.level == "Savannah")
        {
            int level1GameTimes = Int32.Parse(PlayerPrefs.GetString("level1GameTimes"));
            
            level1GameTimes += 1;

            PlayerPrefs.SetString("level1GameTimes", level1GameTimes.ToString());
            PlayerPrefs.Save();
        }

        else if (Game_manager.manager.currentLevel.level == "Mountains")
        {
            int level2GameTimes = Int32.Parse(PlayerPrefs.GetString("level2GameTimes"));

            level2GameTimes += 1;

            PlayerPrefs.SetString("level2GameTimes", level2GameTimes.ToString());
            PlayerPrefs.Save();
        }

        else if (Game_manager.manager.currentLevel.level == "City")
        {
            int level3GameTimes = Int32.Parse(PlayerPrefs.GetString("level3GameTimes"));
            
            level3GameTimes += 1;

            PlayerPrefs.SetString("level3GameTimes", level3GameTimes.ToString());
            PlayerPrefs.Save();
        }
    }

    public void IncreasePlayerData()
    {
        if (Game_manager.manager.currentLevel.level == "Savannah")
        {
            int level1GameTimes = Int32.Parse(PlayerPrefs.GetString("level1GameTimes"));
            float level1LapTime = (float)Convert.ToDouble(PlayerPrefs.GetString("level1LapTime"), CultureInfo.InvariantCulture.NumberFormat);
            string level1RecordCar = PlayerPrefs.GetString("level1RecordCar");

            level1GameTimes += 1;

            if (res < level1LapTime)
            {
                level1LapTime = res;
                level1RecordCar = Game_manager.manager.currentCar.carName.ToString();
                Debug.Log("UUSI ennätysaika: " + level1LapTime.ToString());
            }

            PlayerPrefs.SetString("level1GameTimes", level1GameTimes.ToString());
            PlayerPrefs.SetString("level1LapTime", level1LapTime.ToString("f2").Replace(',', '.'));
            PlayerPrefs.SetString("level1RecordCar", level1RecordCar.ToString());
            PlayerPrefs.Save();
        }

        else if (Game_manager.manager.currentLevel.level == "Mountains")
        {
            int level2GameTimes = Int32.Parse(PlayerPrefs.GetString("level2GameTimes"));
            float level2LapTime = (float)Convert.ToDouble(PlayerPrefs.GetString("level2LapTime"), CultureInfo.InvariantCulture.NumberFormat);
            string level2RecordCar = PlayerPrefs.GetString("level2RecordCar");

            level2GameTimes += 1;

            if (res < level2LapTime)
            {
                level2LapTime = res;
                level2RecordCar = Game_manager.manager.currentCar.carName.ToString();
                Debug.Log("UUSI ennätysaika: " + level2LapTime.ToString());
            }

            PlayerPrefs.SetString("level2GameTimes", level2GameTimes.ToString());
            PlayerPrefs.SetString("level2LapTime", level2LapTime.ToString("f2").Replace(',', '.'));
            PlayerPrefs.SetString("level2RecordCar", level2RecordCar.ToString());
            PlayerPrefs.Save();
        }

        else if (Game_manager.manager.currentLevel.level == "City")
        {
            int level3GameTimes = Int32.Parse(PlayerPrefs.GetString("level3GameTimes"));
            float level3LapTime = (float)Convert.ToDouble(PlayerPrefs.GetString("level3LapTime"), CultureInfo.InvariantCulture.NumberFormat);
            string level3RecordCar = PlayerPrefs.GetString("level3RecordCar");

            level3GameTimes += 1;

            if (res < level3LapTime)
            {
                level3LapTime = res;
                level3RecordCar = Game_manager.manager.currentCar.carName.ToString();
                Debug.Log("UUSI ennätysaika: " + level3LapTime.ToString());
            }

            PlayerPrefs.SetString("level3GameTimes", level3GameTimes.ToString());
            PlayerPrefs.SetString("level3LapTime", level3LapTime.ToString("f2").Replace(',', '.'));
            PlayerPrefs.SetString("level3RecordCar", level3RecordCar.ToString());
            PlayerPrefs.Save();
        }
    }
}
