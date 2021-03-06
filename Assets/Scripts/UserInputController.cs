using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputController : MonoBehaviour
{
    public bool gameIsPaused;
    public bool timerIsOn;
    public Canvas pauseCanvas;
    public Canvas quitCanvas;

    private void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
        quitCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(FindObjectOfType<TimeController>().timerIsOn)
            {
                FindObjectOfType<TimeController>().StopTimer();
                timerIsOn = false;
            }
            gameIsPaused = true;
            quitCanvas.gameObject.SetActive(true);
            if(FindObjectOfType<CarMovement>().audioSound.isPlaying)
            {
                FindObjectOfType<CarMovement>().audioSound.Stop();
            }
        }
        if(FindObjectOfType<TimeController>().timerIsOn && Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<TimeController>().StopTimer();
            gameIsPaused = true;
            pauseCanvas.gameObject.SetActive(true);
            if (FindObjectOfType<CarMovement>().audioSound.isPlaying)
            {
                FindObjectOfType<CarMovement>().audioSound.Stop();
            }
        }
        if (gameIsPaused && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<TimeController>().StartTimer();
            gameIsPaused = false;
            pauseCanvas.gameObject.SetActive(false);
        }
    }

    public void ResumeToGame()
    {
        if (!timerIsOn)
        {
            FindObjectOfType<TimeController>().StartTimer();
            timerIsOn = true;
        }
        gameIsPaused = false;
        quitCanvas.gameObject.SetActive(false);
    }
}
