using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PowerUpController))]
public class PowerModMoveSpeed : PowerMod
{
    [SerializeField] float value = 1.2f;

    protected override void Return()
    {
        GamePlayerSettings.RecoverMoveSpeedMultiplier();
    }

    protected override void DoEffect()
    {
        GamePlayerSettings.currentMoveSpeedMultiplier = value;

    }
}
