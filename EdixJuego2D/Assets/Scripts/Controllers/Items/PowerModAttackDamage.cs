using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModAttackDamage : PowerMod
{
    [SerializeField] float value = 1000;

    protected override void Return()
    {
        GamePlayerSettings.RecoverSavedAttackDamage();
    }

    protected override void DoEffect()
    {
        GamePlayerSettings.currentAttackDamage = value;

    }
}
