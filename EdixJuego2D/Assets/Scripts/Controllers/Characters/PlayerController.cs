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
    public static event Action<int, int> onPlayerLifeChange;
    public static event Action onPlayerDead;        

    public event Action onPlayerJump;
    public event Action onPlayerAttack;

    [SerializeField] int maxLife = 11;
    [SerializeField] float reloadTime = 1f;
    private bool reloading;

    public int currentLife { get; private set; }
  
    public bool isAlive { get; private set; }


    private void OnEnable()
    {
        EndGameManager.onGameWin += DesactivePlayer;
        
    }

    private void OnDisable()
    {
        EndGameManager.onGameWin -= DesactivePlayer;
    }

    private void Start()
    {
        isAlive = true;
        SetLife(maxLife);

        myMovment.onEntityJump = onPlayerJump;
        myAttack.onEntityAttack = onPlayerAttack;
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
        Debug.Log(gameObject.name + " ha muerto ");
        isAlive = false;
        
        if(time > 0)
            Invoke(nameof(DestroyGameObject), time);

        EndGameManager.Instance.Lose();
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
            onPlayerAttack?.Invoke();

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
        myMovment.Move(Input.GetAxisRaw("Horizontal"), GamePlayerSettings.currentMoveSpeedMultiplier);
        if (Input.GetKey(inputJump))
        {
            myMovment.Jump();
        }
            
    }

    private void DesactivePlayer()
    {
        isAlive = false;
        Destroy(gameObject);
    }
  

}
