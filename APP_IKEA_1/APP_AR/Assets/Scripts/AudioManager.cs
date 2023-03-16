using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;

    public void AudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
