using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void SetDamage(int value);
    public void SetDead(float time);
}
