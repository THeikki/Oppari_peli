using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static float time = 0;
    public bool timerIsOn;
    public Text timeCounter;
    
    void Start()
    {
        timeCounter.text = "Time: " + time.ToString("f2").Replace(',', '.');
    }

    void Update()
    {
        UseTimer();
    }

    public void StartTimer()
    {
        timerIsOn = true;
        
    }

    public void StopTimer()
    {
        timerIsOn = false;
    }

    public void UseTimer()
    {
        if (timerIsOn == true)
        {
            time += Time.deltaTime;
            timeCounter.text = "Time: " + time.ToString("f2").Replace(',', '.');
        }
    }

    public void GameOver()
    {
        FindObjectOfType<GameOverMenu>().SetupLapTime(time);
    }
}
