using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public AudioSource playaudio;
   public void playSound(AudioClip clip)
    {
        playaudio.clip = clip;
        playaudio.Play();
    }
}
