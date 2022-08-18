using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSounds : MonoBehaviour
{
    public AudioSource audioSound;

    public void PlayCrashingSound()
    {
        audioSound.Play();
    }
}
