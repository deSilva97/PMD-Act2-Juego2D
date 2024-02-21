using Game.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerControllerNew : MonoBehaviour
    {        
        public event Action onPlayerHit;        

        [Header("References")]
        [SerializeField] PlayerMovment myMovment;

        [Header("Player")]
        [SerializeField] private int life;
        [SerializeField] private int damage; 
        [SerializeField] bool isAlive;

        [Header("Stun")]
        [SerializeField] float timeToStunRecover;
        [SerializeField] bool isStuned;

        private void Start()
        {
            isAlive = true;
        }

       
        private void Update()
        {
            myMovment.canMove = !isStuned;
        }

        public int Attack(Vector2 point)
        {
            myMovment.Bounce(point);

            return damage;
        }

        public void Hit(int damage, Vector2 point)
        {
            
            if (isStuned)
                return;

            life -= damage;
            onPlayerHit?.Invoke();

            if (life <= 0)
            {
                life = 0;
                isAlive = false;
            }

            isStuned = true;
            
            myMovment.ReBounce(point);
            StartCoroutine(LoseControl());
        }
        
        IEnumerator LoseControl()
        {
            yield return new WaitForSeconds(timeToStunRecover);
            isStuned = false;
        }
    }
}

