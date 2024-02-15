using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable 
{
    [SerializeField] EntityMovement myMovment;
    [SerializeField] Animator myAnim;
    [SerializeField] EntityAttack myAttack;

    [SerializeField] EnemyHUD myHUD;


    Transform target;
    SpriteRenderer spr;

    int maxLife = 3;
    [SerializeField] float reloadTime = 0.25f;

    public int currentLife { get; private set; }

    public bool isAlive { get; private set; }

    bool canMove;
    bool reloading;
    private bool climbing;

    public event Action<EnemyController> onEnemyDie;

    const float MIN_DISTANCE_STOP = .5f;

    void Start()
    {              
        currentLife = maxLife;
        isAlive = true;

        EnemyAtRange(FindAnyObjectByType<PlayerController>().transform);
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

            Debug.Log("Moving: " + xDirection);
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

        myHUD.SetLifeBar(currentLife, maxLife);
    }

    public void SetDead(float time = 0)
    {
        onEnemyDie?.Invoke(this);
        Destroy(gameObject);
    }

    public void EnemyAtRange(Transform target)
    {
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

        StartCoroutine(Reload(reloadTime));
        myAnim.SetTrigger("attack");
        myAttack.SetDamageToList(1);
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

