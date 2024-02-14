using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SaveVolume(SoundManager.currentSoundVolume);        
    }

    public void SaveVolume(float value)
    {
        SoundManager.currentSoundVolume = value;
        source.volume = value;
    }
}
