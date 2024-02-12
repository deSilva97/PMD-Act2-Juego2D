using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerAttack myAttack;
    [SerializeField] private Animator myAnimator;
    

    public static Action<int, int> onPlayerLifeChange;
    public static Action onPlayerDead;
    public static Action<int> onCoinsAdd;
    public static Action onKeyPicked;
    public static Action<int> onChestOpen;


    int maxLife = 11;


    public int currentLife { get; private set; }
    public int currentCoins { get; private set; }
    public bool currentKey { get; private set; }

    public int currentChestOpen { get; private set; }

    private void Start()
    {
        SetLife(maxLife);
        SetCoins(0);
        SetChestOpen(0);
    }

    private void Update()
    {
        Attack();
    }

    public void SetLife(int value)
    {
        currentLife = value;
        onPlayerLifeChange?.Invoke(currentLife, maxLife);
    }

    public void PickKey()
    {
        currentKey = true;
        onKeyPicked?.Invoke();
    }

    public void SetCoins(int value)
    {
        currentCoins = value;
        onCoinsAdd?.Invoke(currentCoins);
    }

    public void SetChestOpen(int value)
    {
        currentChestOpen = value;
        onChestOpen?.Invoke(currentChestOpen);
    }

  
    public void SetDamage(int value)
    {
        currentLife -= value;
        if (currentLife < 0)
        {
            currentLife = 0;
            onPlayerDead?.Invoke();
        }

        SetLife(currentLife);
    }

    private void Attack()
    {
        
        if (Input.GetKeyDown(myAttack.getInputkey()))
        {
            myAnimator.SetTrigger("attack");
            myAttack.SetDamageToList(1);
        }
            
    }

    private void Move()
    {

    }

}
