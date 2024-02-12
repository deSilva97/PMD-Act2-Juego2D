using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    public static Action<int, int> onPlayerLifeChange;
    public static Action onPlayerDead;
    public static Action<int> onCoinsAdd;
    public static Action onKeyPicked;
    public static Action<int> onChestOpen;


    int maxLife = 11;


    public int currentLife { get; private set; }
    public int currentCoins { get; private set; }
    public bool currentKey { get; private set; }

    public int currentChestOpen { get; private set; }


    public void SetLife(int value)
    {
        currentLife = value;
        onPlayerLifeChange?.Invoke(currentLife, maxLife);
    }

    public void PickKey()
    {
        currentKey = true;
        onKeyPicked?.Invoke();
    }

    public void SetCoins(int value)
    {
        currentCoins = value;
        onCoinsAdd?.Invoke(currentCoins);
    }

    public void SetChestOpen(int value)
    {
        currentChestOpen = value;
        onChestOpen?.Invoke(currentChestOpen);
    }

    private void Start()
    {
        SetLife(maxLife);
        SetCoins(0);
        SetChestOpen(0);
        InvokeRepeating("_", 1f, 1f);        
    }

    private void _()
    {
        SetDamage(2);
    }

    public void SetDamage(int value)
    {
        currentLife -= value;
        if (currentLife < 0)
        {
            currentLife = 0;
            onPlayerDead?.Invoke();
        }

        SetLife(currentLife);
    }

}
