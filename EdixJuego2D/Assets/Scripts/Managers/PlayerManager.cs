using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    public static event Action<int> onLifesChanges;
    public static event Action<bool> onKeyPicked;
    public static event Action<int> onCoinPicked;
    public static event Action<int> onChestOpened;

    private bool currentKey;
    private int currentCoins;
    private int currentChestOpen;

    private void Start()
    {
        setKey(false);
        setCoins(0);
        setChests(0);
    }

    public bool getKey() => currentKey;
    public void setKey(bool value)
    {
        currentKey = value;
        onKeyPicked?.Invoke(value);
    }

    public int getCoins() => currentCoins;
    public void setCoins(int value)
    {
        currentCoins = value;
        onCoinPicked?.Invoke(value);
    }
    public int getChests() => currentChestOpen;
    public void setChests(int value)
    {
        currentChestOpen = value;
        onChestOpened?.Invoke(value);
    }

}
