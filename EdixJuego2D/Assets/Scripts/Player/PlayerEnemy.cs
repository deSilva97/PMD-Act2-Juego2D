using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] bool canBeHitted = true;
    [Header("Time")]
    [SerializeField] float timeToRecover;

    public bool isStuned { get; private set; }

    PlayerController player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<PlayerController>();

            if (canBeHitted && collision.GetContact(0).normal.y <= -.9)
            {
                int damage = player.Attack(collision.GetContact(0).normal);
                //Stun();
            }
            else
            {
                player.Hit(1, collision.GetContact(0).normal);
                Stun();
            }

        }
    }    

    private void Stun()
    {
        isStuned = true;
        Invoke(nameof(Recover), timeToRecover);
    }

    private void Recover() => isStuned = false;
}
