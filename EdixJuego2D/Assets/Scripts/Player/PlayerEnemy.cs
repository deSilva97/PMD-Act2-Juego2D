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
            Debug.Log(gameObject.name + " ha detectado a " + collision.gameObject.name);
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (canBeHitted && collision.GetContact(0).normal.y <= -.9)
            {
                int damage = player.Attack(collision.GetContact(0).normal);
                Debug.Log("Recibo da�o x" + damage);
            }
            else
            {
                player.Hit(1, collision.GetContact(0).normal);

            }

        }
    }
}
