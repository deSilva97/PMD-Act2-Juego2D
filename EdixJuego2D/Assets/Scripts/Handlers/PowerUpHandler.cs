using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerUpHandler
{
    public enum Types : byte {None, VelocityUp, InstaKill }

    public static Types currentType { get; private set; }

    static Coroutine powerUp;
    public static float powerUpTimer { get; private set; }

    public static void ChangePowerUp(Types type, float value, float timer)
    {
        if(type == Types.None && powerUp != null)
        {
            powerUp = null;
        }
    }
}
