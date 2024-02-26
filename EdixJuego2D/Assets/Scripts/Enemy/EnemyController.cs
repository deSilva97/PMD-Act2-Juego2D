using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event Action<EnemyController> onEnemyDie;

    [Header("Data")]
    [SerializeField] Enemy data;
    [Header("References")]
    [SerializeField] PlayerEnemy myLife;
    [SerializeField] EnemyMovment myMovment;
    [SerializeField] Animator myAnimator;

    [Header("Enemy")]
    [SerializeField] bool startSleep;
    [SerializeField] float jumpDeadStrenght = 5;
    [SerializeField] bool isAlive;
    [SerializeField] bool isDead;

    bool isSleeping;

    private void Start()
    {
        if(data != null)
        {
            myLife.SetLife(data.Health);
            myLife.SetDamage(data.Damage);
            myLife.SetTimeToRecover(data.TimeStuned);

            myMovment.SetMoveSpeed(data.MoveSpeed);
        }

        isAlive = true;

        isSleeping = startSleep;
    }

    private void Update()
    {
        if (!isAlive)
            return;

        isAlive = myLife.GetLife() > 0;        

        myMovment.canMove = !myLife.isStuned && !isSleeping;
        myAnimator.SetBool("move", myMovment.canMove);
        
        if(!isAlive )
        {
            Dead();
        }
    }

    private void Dead()
    {
        LevelManager.Instance.AddPoints(data.Points);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpDeadStrenght, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
        myAnimator.SetTrigger("dead");
        onEnemyDie?.Invoke(this);
        Destroy(gameObject, 1f);
    }
}
