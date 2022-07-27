using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSounds : MonoBehaviour
{
    public AudioSource audioSound;

    private void Start()
    {
        audioSound = GetComponent<AudioSource>();
    }

    public void PlayCrashingSound()
    {
        audioSound.Play();
    }
}
