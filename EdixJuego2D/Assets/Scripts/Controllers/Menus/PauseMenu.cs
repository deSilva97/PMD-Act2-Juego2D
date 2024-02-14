using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : PausableMenu
{
    [Header("References")]
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueGameButton;
    [SerializeField] Button exitButton;
    protected new void Start()
    {
        base.Start();
        setListeners();
        Close();
    }

    public override void Open()
    {
        TimeManager.Pause();
        content.SetActive(true);
    }

    public override void Close()
    {
        TimeManager.Resume();
        content.SetActive(false);
    } 

    private void setListeners()
    {
        newGameButton.onClick.AddListener(HandleNewGame);
        continueGameButton.onClick.AddListener(HandleContinue);
        exitButton.onClick.AddListener(HandleExit);
    }

    private void HandleNewGame()
    {
        Debug.Log("Nueva partida");
        SceneManager.LoadScene(1);        
    }

    private void HandleContinue()
    {
        isOpen = false;
        Close();
    }

    private void HandleExit()
    {
        Close();
        SceneManager.LoadScene(0);
    }

}
