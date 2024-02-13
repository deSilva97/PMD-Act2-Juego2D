using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Inputs")]
    [SerializeField] KeyCode inputJump = KeyCode.Space;
    [SerializeField] KeyCode inputAttack = KeyCode.X;

    [Header("References")]
    [SerializeField] private EntityMovement myMovment;
    [SerializeField] private EntityAttack myAttack;
    [SerializeField] private Animator myAnimator;
    
    //Events
    public static Action<int, int> onPlayerLifeChange;
    public static Action onPlayerDead;
    public static Action<int> onCoinsAdd;
    public static Action onKeyPicked;
    public static Action<int> onChestOpen;


    [SerializeField] int maxLife = 11;
    [SerializeField] float reloadTime = 1f;
    private bool reloading;

    public int currentLife { get; private set; }
    public int currentCoins { get; private set; }
    public bool currentKey { get; private set; }

    public int currentChestOpen { get; private set; }

    public bool isAlive { get; private set; }

    private void Start()
    {
        isAlive = true;
        SetLife(maxLife);
        GiveCoin(0);
        ChestIndexOpen(0);
    }

    private void Update()
    {
        if (!isAlive)
            return;

            Move();
            Attack();
    }

    public void SetLife(int value)
    {
        currentLife = value;
        onPlayerLifeChange?.Invoke(currentLife, maxLife);
    }

    public void GiveKey()
    {
        currentKey = true;
        onKeyPicked?.Invoke();
    }

    public void GiveCoin(int value = 1)
    {
        currentCoins += value;
        onCoinsAdd?.Invoke(currentCoins);
    }

    public void ChestIndexOpen(int value)
    {
        currentChestOpen = value;
        onChestOpen?.Invoke(currentChestOpen);
    }

  
    public void SetDamage(int value)
    {
        currentLife -= value;
        if (currentLife <= 0)
        {
            currentLife = 0;
            SetDead(1f);
        }

        SetLife(currentLife);
    }

    public void SetDead(float time = 0)
    {
        isAlive = false;

        if(time > 0)
            Invoke(nameof(DestroyGameObject), time);
    }

    public void DestroyGameObject()
    {
        onPlayerDead?.Invoke();
        Destroy(gameObject);
    }

    private void Attack()
    {        
        if (Input.GetKey(inputAttack) && !reloading)
        {
            StartCoroutine(Reload(reloadTime));
            myAnimator.SetTrigger("attack");
            myAttack.SetDamageToList(1);
        }
            
    }
    IEnumerator Reload(float time)
    {
        reloading = true;
        yield return new WaitForSeconds(time);
        reloading = false;
    }

    private void Move()
    {
        myMovment.Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(inputJump))
            myMovment.Jump();
    }


  

}
