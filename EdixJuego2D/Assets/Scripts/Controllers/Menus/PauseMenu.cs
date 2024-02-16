using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    [Header("Inputs")]
    [SerializeField] protected KeyCode inputKey;
    [SerializeField] protected Button inputButton;

    [Header("Content")]
    [SerializeField] protected GameObject content;

    [Header("References")]
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueGameButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button exitButton;

    public bool isOpen { get; protected set; }

    protected void Start()
    {
        if (inputButton != null)
            inputButton.onClick.AddListener(HandleInputs);

        setListeners();

        Close();
    }

    protected void Update()
    {
        if (Input.GetKeyDown(inputKey))
            HandleInputs();
    }

    protected void HandleInputs()
    {
        if (isOpen)
            HandleContinue();
        else Open();
    }

    public override void Open()
    {
        isOpen = true;
        TimeManager.Pause();
        content.SetActive(true);
    }

    public override void Close()
    {
        content.SetActive(false);
    } 

    private void setListeners()
    {
        newGameButton.onClick.AddListener(HandleNewGame);
        continueGameButton.onClick.AddListener(HandleContinue);
        settingsButton.onClick.AddListener(HandleSettings);
        exitButton.onClick.AddListener(HandleExit);
    }

    private void HandleNewGame()
    {
        TimeManager.Resume();
        SceneController.Instance.LoadActiveScene();        
    }

    private void HandleContinue()
    {
        isOpen = false;
        TimeManager.Resume();
        Close();
    }

    private void HandleSettings()
    {
        MenuHandler.changeMenu(FindAnyObjectByType<SettingsMenu>(), this, true);
    }

    private void HandleExit()
    {
        Close();
        SceneController.Instance.LoadScene("MainMenuScene");
    }

}
