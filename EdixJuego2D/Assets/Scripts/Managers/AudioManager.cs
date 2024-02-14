using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance => instance;

    [SerializeField] AudioMixer mixer;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        SetMusicVolume(LoadMusicVolume());
        SetSFXVolume(LoadSFXVolume());
    }

    public void SetMusicVolume(float value)
    {
        if(value > 0)
            mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        else mixer.SetFloat(MIXER_MUSIC, -80);
    }

    public void SetSFXVolume(float value)
    {
        if (value > 0)
            mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        else mixer.SetFloat(MIXER_SFX, -80);
    }

    public static void SaveMusicVolume(float value) => PlayerPrefs.SetFloat(nameof(MIXER_MUSIC), value);
    public static void SaveSFXVolume(float value) => PlayerPrefs.SetFloat(nameof(MIXER_SFX), value);

    public static float LoadMusicVolume() => PlayerPrefs.GetFloat(nameof(MIXER_MUSIC), -15);
    public static float LoadSFXVolume() => PlayerPrefs.GetFloat(nameof(MIXER_SFX), -15);
}
