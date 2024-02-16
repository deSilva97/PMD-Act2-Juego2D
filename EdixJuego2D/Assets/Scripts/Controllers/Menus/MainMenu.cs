using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;

    void Start()
    {
        playButton.onClick.AddListener(() => MenuHandler.changeMenu(FindAnyObjectByType<LevelMenu>()));
        optionsButton.onClick.AddListener(() => MenuHandler.changeMenu(FindObjectOfType<SettingsMenu>()));
        exitButton.onClick.AddListener(() => Application.Quit());
    }
}
