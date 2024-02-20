using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private Player data;
    [Header("References")]
    [SerializeField] private CharacterMovment myMovment;
    [SerializeField] private Animator myAnimator;
    
    //Events
    public static event Action<int, int> onPlayerLifeChange;
    public static event Action onPlayerDead;        
    public static event Action onPlayerRespawn;

    public event Action onPlayerJump;

    //[SerializeField] int maxLife = 11;
    //[SerializeField] float reloadTime = 1f;
    private bool reloading;

    public int currentLife { get; private set; }
  
    public bool isAlive { get; private set; }

    Vector3 respawnPositon;

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
        myMovment.SetMoveSpeed(data.MoveSpeed);
        myMovment.SetJumpStrength(data.JumpStrength);

        myMovment.onEntityJump = onPlayerJump;

        respawnPositon = transform.position;

        PlayerManager.Instance.setExtraLifes(data.ExtraLifes);

        ReSpawn();
    }


    private void ReSpawn()
    {
        transform.position = respawnPositon;
        isAlive = true;
        SetLife(data.Health);
    }

    public void SetLife(int value)
    {
        currentLife = value;

        if (currentLife < 0) 
            currentLife = 0;
        else if (currentLife > data.MaxHealth) 
            currentLife = data.MaxHealth;

        onPlayerLifeChange?.Invoke(currentLife, data.MaxHealth);
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
        int nLives = PlayerManager.Instance.getExtraLifes();
        nLives--;

        if(nLives < 0)
        {
            EndGameManager.Instance.Lose();
            
            isAlive = false;

            if (time > 0)
                Invoke(nameof(DestroyGameObject), time);
        }
        else
        {
            PlayerManager.Instance.setExtraLifes(nLives);
            ReSpawn();
        }
    }

    public void DestroyGameObject()
    {
        onPlayerDead?.Invoke();
        Destroy(gameObject);
    }

    public void Attack(bool input)
    {        
        if (input && !reloading)
        {
            StartCoroutine(Reload(data.IntervalAttack));
            myAnimator.SetTrigger("attack");
        }
    }
    IEnumerator Reload(float time)
    {
        reloading = true;
        yield return new WaitForSeconds(time);
        reloading = false;
    }

    public void Move(float x, bool jumpInput)
    {
        myMovment.Move(x, GamePlayerSettings.currentMoveSpeedMultiplier);
        if (jumpInput)
        {
            myMovment.TryJump();
        }
            
    }

    public void Jump() => myMovment.TryJump();

    private void DesactivePlayer()
    {
        isAlive = false;
        Destroy(gameObject);
    }
  

}
