using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public static class PlayerManager 
{
    public static Action<bool> onKeyPicked;    

    public static bool currentKey { get; private set; }


    public static void PickUpCoin()
    {

    }

    public static bool PickUpKey()
    {
        if (currentKey)
            return false;

        currentKey = true;
        onKeyPicked?.Invoke(currentKey);
        return true;
    }

    public static void UseKey()
    {
        currentKey = false;
        onKeyPicked?.Invoke(currentKey);
    }



}
