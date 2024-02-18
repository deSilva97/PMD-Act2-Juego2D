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
    private int currentExtraLifes;
    private bool currentKey;
    private int currentChestOpen;

    public static event Action<int> onExtraLifesChanges;
    public static event Action<int> onLifesChanges;
    public static event Action<bool> onKeyPicked;
    public static event Action<int> onChestOpened;

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

    public int getExtraLifes() => currentExtraLifes;
    public void setExtraLifes(int value)
    {
        currentExtraLifes = value;
        onExtraLifesChanges?.Invoke(value);
    }

}
