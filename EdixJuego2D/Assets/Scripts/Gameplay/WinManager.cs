using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static event Action onGameWin;
    public static event Action onGameLose;

    private static WinManager instance;
    public static WinManager Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }


    public void Win() => onGameWin?.Invoke();
    public void Lose() => onGameLose?.Invoke();
}
