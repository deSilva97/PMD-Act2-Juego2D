using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PowerUpController))]
public abstract class PowerMod : MonoBehaviour
{
    [SerializeField] PowerUpStruct myStruct;
    PowerUpController controller;
    private void Awake()
    {
        controller = GetComponent<PowerUpController>();
    }

    private void Start()
    {
        controller.onPickUp += Apply;
    }

    private void Apply()
    {
        PowerUpManager.Instance.ChangePowerUp(myStruct, Return);
        DoEffect();
    }

    protected abstract void Return();    

    protected abstract void DoEffect();
}

