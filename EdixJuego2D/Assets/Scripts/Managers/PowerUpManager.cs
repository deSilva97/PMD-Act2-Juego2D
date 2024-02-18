using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUP : byte {SpeedUp, InstaKill}

[System.Serializable]
public struct PowerUpStruct
{
    public PowerUP powerUp;
    public float maxTime;
}

public class PowerUpManager : MonoBehaviour
{
    private static PowerUpManager instance;
    public static PowerUpManager Instance => instance;

    public static event Action<string> onPowerUpIn;
    public static event Action onPowerUpOut;
    public static event Action<float, float> onCurrentTimeChanges;


    IEnumerator currentEnumerator;
    PowerUpStruct currentPowerUp;
    float currentTime;
    Action currentCallback;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    public void ChangePowerUp(PowerUpStruct power, Action callback)
    {
        Debug.Log("Activando poder: " + power);

        currentTime = power.maxTime;

        if (currentEnumerator == null)
        {
            currentPowerUp = power;

            currentCallback = callback;
            currentEnumerator = PowerUpSytem(callback);
            StartCoroutine(currentEnumerator);
        }
        else if(power.powerUp != currentPowerUp.powerUp)
        {
            StopAllCoroutines();
            currentCallback?.Invoke();
            currentCallback = null;
            currentEnumerator = null;
            ChangePowerUp(power, callback);
        }
        
    }
    IEnumerator PowerUpSytem(Action callback)
    {
        onPowerUpIn?.Invoke(currentPowerUp.powerUp.ToString());
        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            onCurrentTimeChanges?.Invoke(currentTime, currentPowerUp.maxTime);
            yield return new WaitForEndOfFrame();
        }
        callback?.Invoke();
        onPowerUpOut?.Invoke();
        currentEnumerator = null;
    }

}
