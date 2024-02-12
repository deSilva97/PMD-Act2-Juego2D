using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityLife : MonoBehaviour
{

    public int currentLife { get; protected set; }
    protected int maxLife = 1;

    public void SetDamage(int value = 1)
    {
        currentLife -= value;
        if (currentLife < 0)
            currentLife = 0;     
    }

}
