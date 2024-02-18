using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField] GameObject content;

    [SerializeField] Button saveButton;
    [SerializeField] Button cancelButton;

    [Header("Volume")]    
    [SerializeField] VolumeUI musicUI;
    [SerializeField] VolumeUI soundsUI;

    private void Awake()
    {
        saveButton.onClick.AddListener(SaveAndClose);
        cancelButton.onClick.AddListener(Close);
    }

    private void Start()
    {
        musicUI.onVolumeChange += (ctx) => AudioManager.Instance.SetMusicVolume(ctx); 
        soundsUI.onVolumeChange += (ctx) => AudioManager.Instance.SetSFXVolume(ctx);

        Close();
    }

   

    public void SaveAndClose()
    {
        AudioManager.SaveMusicVolume(musicUI.GetSliderValue());
        AudioManager.SaveSFXVolume(soundsUI.GetSliderValue());

        Close();
    }
    public override void Open()
    {
        content.SetActive(true);
        musicUI.Open(AudioManager.LoadMusicVolume());
        soundsUI.Open(AudioManager.LoadSFXVolume());
    }

    public override void Close()
    {
        content.SetActive(false);
        MenuHandler.returnMenu();
    }

}
