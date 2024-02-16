using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {Main, Gameplay}

public class GameManager : MonoBehaviour
{
    public GameState currentState { get; private set; }

    private static GameManager instance;
    public static GameManager Instance => instance;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeState(GameState state)
    {       
        currentState = state;

        switch (currentState)
        {
            case GameState.Main: 
                SceneManager.LoadScene(0);
                break;
            case GameState.Gameplay:
                SceneManager.LoadScene(1);
                break;    
            default: Debug.LogWarning("Cambio de estado no definido");
                break;                
        }
    }

    [ContextMenu("Reset Player Prefs")]
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
