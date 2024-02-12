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

    [SerializeField] Transform target;
    [SerializeField] EnemyHUD myHUD;

    SpriteRenderer spr;

    int maxLife = 3;
    [SerializeField] float reloadTime = 0.25f;

    public int currentLife { get; private set; }

    bool canMove;
    bool reloading;
    void Start()
    {              
        currentLife = maxLife;

        EnemyAtRange(FindAnyObjectByType<PlayerController>().transform);
    }

    private void Update()
    {
        if (canMove)
        {
            float xDirection = 0;
            float distance = (target.position.x - transform.position.x);

            if (distance < -.5f)
            {
                xDirection = -1;

            }             
            else if (distance > .5f)
            {
                xDirection = 1;


            }
            else
            {
                float yDistance = target.position.y - transform.position.y;


                if (yDistance < .5f)
                {
                    Attack();
                }

            }
            
            myMovment.Move(xDirection);
        }
    }

    public void SetDamage(int value)
    {
        currentLife -= value;

 
        if (currentLife <= 0)
            Destroy(gameObject);

        myHUD.SetLifeBar(currentLife, maxLife);
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
        myMovment.Jump();
    }
}

