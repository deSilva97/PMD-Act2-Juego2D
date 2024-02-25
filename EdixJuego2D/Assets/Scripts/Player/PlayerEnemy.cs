using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int damage;
    [SerializeField] bool canBeHitted = true;
    [Header("Time")]
    [SerializeField] float timeToRecover;
    public bool isStuned { get; private set; }

    PlayerController player;

    public int GetLife() => life;
    public int SetLife(int value) => life = value;
    public int SetDamage(int value) => damage = value;
    public float SetTimeToRecover(float value) => timeToRecover = value;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<PlayerController>();

            if (canBeHitted && collision.GetContact(0).normal.y <= -.9)
            {
                int damage = player.Attack(collision.GetContact(0).normal);
                life -= damage;
                //Stun();
            }
            else
            {
                StartCoroutine(Attack(collision.GetContact(0).normal));
                Stun();
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;

        }
    }

    IEnumerator Attack(Vector2 point)
    {
        while (player)
        {
            player.Hit(damage, point);
            yield return new WaitForSeconds(timeToRecover);
        }
    }

    private void Stun()
    {
        isStuned = true;
        Invoke(nameof(Recover), timeToRecover);
    }

    private void Recover() 
    { 
        isStuned = false;
    } 
}
