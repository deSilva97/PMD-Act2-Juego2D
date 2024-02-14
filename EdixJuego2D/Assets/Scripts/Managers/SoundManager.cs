using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static float currentMusicVolume
    {
        get { return PlayerPrefs.GetFloat(nameof(currentMusicVolume), .1f); }
        set { PlayerPrefs.SetFloat(nameof(currentMusicVolume), value); }
    }

    public static float currentSoundVolume
    {
        get { return PlayerPrefs.GetFloat(nameof(currentSoundVolume), .1f); }
        set { PlayerPrefs.SetFloat(nameof(currentSoundVolume), value); }
    }

}
