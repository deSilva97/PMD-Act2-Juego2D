using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    static SettingsMenu currentInstance;    
    public static void OpenSettings(GameObject returnContent) => currentInstance.Open(returnContent);

    [SerializeField] GameObject content;

    private GameObject lastContent;

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
   

        currentInstance = this;
        Close();
    }

    public void Open(GameObject returnContent)
    {
        lastContent = returnContent;

        content.SetActive(true);
        musicUI.Open(SoundManager.currentMusicVolume);
        soundsUI.Open(SoundManager.currentSoundVolume);
    }

    public void SaveAndClose()
    {
        SoundManager.currentMusicVolume = musicUI.GetSliderValue();
        SoundManager.currentSoundVolume = soundsUI.GetSliderValue();
        Close();
    }

    public void Close()
    {
        content.SetActive(false);
        if(lastContent != null)
            lastContent.SetActive(true);
    }

}
