using System;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public AudioSource audioSource;

    public void ToggleAudio()
    {
        if (audioSource == null) return;

        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }

    public void summa()
    {
        Debug.Log("Button");
    }
}
