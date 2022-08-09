using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputController : MonoBehaviour
{
    public bool gameIsPaused;
    public bool quitIsPressed;
    public bool pauseIsPressed;
    public bool timerWasOn;
    public Canvas pauseCanvas;
    public Canvas quitCanvas;

    private void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
        quitCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseIsPressed)
        {
            if(FindObjectOfType<TimeController>().timerIsOn)
            {
                FindObjectOfType<TimeController>().StopTimer();
                timerWasOn = true;
            }
            gameIsPaused = true;
            quitIsPressed = true;
            quitCanvas.gameObject.SetActive(true);
            if(FindObjectOfType<CarMovement>().audioSound.isPlaying)
            {
                FindObjectOfType<CarMovement>().audioSound.Stop();
            }
        }
        else if(FindObjectOfType<TimeController>().timerIsOn && Input.GetKeyDown(KeyCode.Space) && !quitIsPressed)
        {
            FindObjectOfType<TimeController>().StopTimer();
            gameIsPaused = true;
            pauseIsPressed = true;
            pauseCanvas.gameObject.SetActive(true);
            if (FindObjectOfType<CarMovement>().audioSound.isPlaying)
            {
                FindObjectOfType<CarMovement>().audioSound.Stop();
            }
        }
        else if(pauseIsPressed && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<TimeController>().StartTimer();
            gameIsPaused = false;
            pauseIsPressed = false;
            pauseCanvas.gameObject.SetActive(false);
        }
    }

    public void ResumeToGame()
    {
        if (timerWasOn)
        {
            FindObjectOfType<TimeController>().StartTimer();
            timerWasOn = false;
        }
        quitIsPressed = false;
        gameIsPaused = false;
        quitCanvas.gameObject.SetActive(false);
    }
}
