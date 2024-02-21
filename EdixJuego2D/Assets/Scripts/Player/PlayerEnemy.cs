using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] bool canBeHitted = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            PlayerControllerNew player = collision.gameObject.GetComponent<PlayerControllerNew>();

            if (canBeHitted && collision.GetContact(0).normal.y <= -.9)
            {
                int damage = player.Attack(collision.GetContact(0).normal);
                Debug.Log("Recibo daño x" + damage);
            }
            else
            {
                player.Hit(1, collision.GetContact(0).normal);

            }

        }
    }
}
