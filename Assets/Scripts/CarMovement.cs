using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public AudioSource audioSound;
    
    void Update()
    {
        MoveControl();
    }

    void PlayMotorSound()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSound.Play();
        }
        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            audioSound.Stop();
        }
    }

    public void MoveControl()
    {
        if(!FindObjectOfType<UserInputController>().gameIsPaused)
        {
            float verticalMovement = Input.GetAxis("Vertical") * speed;
            float horizontalMovement = Input.GetAxis("Horizontal") * turnSpeed;

            verticalMovement *= Time.deltaTime;
            horizontalMovement *= Time.deltaTime;
            transform.Translate(0, verticalMovement, 0);
            transform.Rotate(0, 0, -horizontalMovement);
           
            PlayMotorSound();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "elephant")
        {
            FindObjectOfType<PenaltyController>().AddHit(3);
            FindObjectOfType<CrashSounds>().PlayCrashingSound();
        }
        else if (collision.gameObject.tag == "bighorn")
        {
            FindObjectOfType<PenaltyController>().AddHit(3);
            FindObjectOfType<CrashSounds>().PlayCrashingSound();
        }
        else if (collision.gameObject.tag == "bus")
        {
            FindObjectOfType<PenaltyController>().AddHit(2);
            FindObjectOfType<CrashSounds>().PlayCrashingSound();
        }
        else if (collision.gameObject.tag == "jeep")
        {
            FindObjectOfType<PenaltyController>().AddHit(1);
            FindObjectOfType<CrashSounds>().PlayCrashingSound();
        }
        else if (collision.gameObject.tag == "tree")
        {
            FindObjectOfType<PenaltyController>().AddHit(1);
            FindObjectOfType<CrashSounds>().PlayCrashingSound();
        }
        else if (collision.gameObject.tag == "stopLine")
        {
            FindObjectOfType<TimeController>().StopTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "startLine")
        {
            FindObjectOfType<TimeController>().StartTimer();
            collision.isTrigger = false;
        }
        else if (collision.gameObject.tag == "stopLine")
        {
            SceneManager.LoadScene("GameOver-menu");
        }
    }
}