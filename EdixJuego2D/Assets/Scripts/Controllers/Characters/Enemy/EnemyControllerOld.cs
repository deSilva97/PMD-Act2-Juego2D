using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyControllerOld : MonoBehaviour, IDamageable 
{
    [SerializeField] Enemy myData;
    [Space]
    [SerializeField] CharacterMovment myMovment;
    [SerializeField] Animator myAnim;
    [SerializeField] CharacterAttack myAttack;
    [SerializeField] EnemyHUD myHUD;

    public Transform target { get; set; }
    SpriteRenderer spr;

    public int currentLife { get; private set; }

    public bool isAlive { get; private set; }

    bool canMove;
    bool reloading;
    private bool climbing;

    public event Action<EnemyControllerOld> onEnemyDie;

    const float MIN_DISTANCE_STOP = .5f;

    void Start()
    {              
        currentLife = myData.Health;
        myMovment.SetMoveSpeed(myData.MoveSpeed); 
        myMovment.SetJumpStrength(myData.JumpStrength); 
        isAlive = true;

        //EnemyAtRange(FindAnyObjectByType<PlayerController>().transform);
    }

    private void Update()
    {
        if (target == null)
            return;

        if (myAttack.canAttack())
        {
            Attack();
            return;
        }

        if (canMove)
        {
            float xDirection = 0;
            //float distance = !climbing ? (target.position.x - transform.position.x) : 0;
            float distance = (target.position.x - transform.position.x);

            if (distance < -MIN_DISTANCE_STOP)
            {
                xDirection = -1;
                transform.localScale = new Vector3(-1, 1, 1);

            }             
            else if (distance > MIN_DISTANCE_STOP)
            {
                xDirection = 1;
                transform.localScale = new Vector3(1, 1, 1);
            }
            
            if(climbing)
            {
                xDirection = 0;
            }

            /*
            if(xDirection == 0)
            {
                if((target.position.x - transform.position.x) < 0)
                    transform.localScale = new Vector3(-1, 1, 1);
                else if((target.position.x - transform.position.x) > 0)
                    transform.localScale = new Vector3(1, 1, 1);
            }
            */
            myMovment.Move(xDirection);
        }
    }

    public void SetDamage(int value)
    {
        currentLife -= value;

        if (currentLife <= 0)
            SetDead();

        myHUD.SetLifeBar(currentLife, myData.Health);
    }

    public void SetDead(float time = 0)
    {
        onEnemyDie?.Invoke(this);
        LevelManager.Instance.AddPoints(myData.Points);
        Destroy(gameObject);
    }

    public void EnemyAtRange(Transform target)
    {
        canMove = false;
        if (this.target == target)
            return;
        
        this.target = target;
        transform.localScale = new Vector3((target.position.x < transform.position.x) ? -1 : 1, 1,1 );
        myHUD.SetNotify("!");
        Invoke("StartMoving", 1f);
    }

    public void StartMoving()
    {
        myHUD.SetNotify();
        canMove = true;
    }

    public void Attack()
    {
        if (reloading)
            return;        

        StartCoroutine(Reload(myData.IntervalAttack));
        myAnim.SetTrigger("attack");
        myAttack.SetDamageToList(myData.Damage);
    }

    IEnumerator Reload(float time)
    {
        reloading = true;
        yield return new WaitForSeconds(time);
        reloading = false;
    }

    public void Climb()
    {
        climbing = true;
        myMovment.Jump();
    }

    public void StopClimb() => climbing = false;
}

