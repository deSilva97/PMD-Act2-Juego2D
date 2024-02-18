using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static event Action onGameWin;
    public static event Action onGameLose;

    private static EndGameManager instance;
    public static EndGameManager Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }


    public void Win() => onGameWin?.Invoke();
    public void Lose() => onGameLose?.Invoke();
}
