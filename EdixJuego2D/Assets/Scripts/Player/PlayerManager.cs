using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static event Action<bool> onKeyPicked;
    public static event Action<int> onChestOpened;
    public static event Action onPlayerDead;

    private static PlayerManager instance;
    public static PlayerManager Instance => instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    private int currentExtraLifes;
    private bool currentKey;
    private int currentChestOpen;

    private void Start()
    {
        setKey(false);
        setChests(0);
    }

    public bool getKey() => currentKey;
    public void setKey(bool value)
    {
        currentKey = value;
        onKeyPicked?.Invoke(value);
    }
    
    public int getChests() => currentChestOpen;
    public void setChests(int value)
    {
        currentChestOpen = value;
        onChestOpened?.Invoke(value);
    }


    public void SetPlayerDead() => onPlayerDead?.Invoke();

}
