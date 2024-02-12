using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action<int> onCoinsAdd;
    public static Action onKeyPicked;

    public int currentCoins { get; private set; }
    public bool currentKey { get; private set; }

    public void PickKey()
    {
        currentKey = true;
        onKeyPicked?.Invoke();
    }

    public void AddCoin()
    {
        currentCoins++;
        onCoinsAdd?.Invoke(currentCoins);
    }
}
