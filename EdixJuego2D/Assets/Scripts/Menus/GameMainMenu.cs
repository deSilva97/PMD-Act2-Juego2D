using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameMainMenu : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] KeyCode inputKey;
    [SerializeField] Button inputButton;

    [Header("References")]
    [SerializeField] GameObject content;
    [Space]
    [SerializeField] Button newGameButton;
    [SerializeField] Button continueGameButton;
    [SerializeField] Button exitButton;
    [Space]
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider soundVolumeSlider;

    private void Start()
    {
        setListeners();
        Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(inputKey))
            HandleInputs();        
    }    

    private void HandleInputs()
    {
        if (Time.timeScale == 0)
            Close();
        else Open();
    }

    public void Open()
    {
        TimeManager.Pause();
        content.SetActive(true);
    }

    public void Close()
    {
        TimeManager.Resume();
        content.SetActive(false);
    } 

    private void setListeners()
    {
        if (inputButton != null)
            inputButton.onClick.AddListener(HandleInputs);

        newGameButton.onClick.AddListener(HandleNewGame);
        continueGameButton.onClick.AddListener(HandleContinue);
        exitButton.onClick.AddListener(HandleExit);
    }

    private void HandleNewGame()
    {
        Debug.Log("Nueva partida");
        GameManager.Instance.ChangeState(GameState.Gameplay);
    }

    private void HandleContinue()
    {       
        Debug.Log("Continuar partida");
        Close();
    }

    private void HandleExit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

}
