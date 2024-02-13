using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IDamageable
{
    int hits = 3;

    public void SetDamage(int value)
    {
        hits--;

        if (hits <= 0)
            SetDead();

    }

    public void SetDead(float time = 0)
    {
        
        Destroy(gameObject);
    }

}
