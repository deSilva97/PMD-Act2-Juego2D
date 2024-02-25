using Game.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour, IKilleable
    {        
        public static event Action<int, int> onPlayerLifeChanges;
        public event Action<PlayerController, Vector2> onPlayerHit;
        public event Action<PlayerController> onPlayerDeath;

        [Header("References")]
        [SerializeField] PlayerMovment myMovment;
        [SerializeField] PlayerAnimation myAnimations;
        [SerializeField] GameObject myMesh;

        [Header("Player")]
        [SerializeField] private int myLife;
        [SerializeField][Range(0, 1)] private float startLifePercentage = 1;
        [SerializeField] private int myDamage; 
        [SerializeField] bool isAlive;

        int currentLife;

        [Header("Stun")]
        [SerializeField] float timeToStunRecover;
        [SerializeField] bool isStuned;

        private void Start()
        {
            isAlive = true;
            
            currentLife = (int)(myLife * startLifePercentage);
            onPlayerLifeChanges?.Invoke(currentLife, myLife);
        }

       
        private void Update()
        {
            myMovment.canMove = !isStuned;
            myAnimations.Jumping(!myMovment.isGrounded);
        }

        public int Attack(Vector2 point)
        {
            myMovment.Bounce(point, myMovment.GetJumpStrenght());

            return myDamage;
        }

        public void RecoverLife(int value)
        {
            currentLife += value;
            if (currentLife > myLife)
                currentLife = myLife;

            onPlayerLifeChanges?.Invoke(currentLife, myLife);
        }

        public void Hit(int damage, Vector2 point)
        {
            if (isStuned)
                return;

            currentLife -= damage;
            onPlayerHit?.Invoke(this, point);

            if (currentLife <= 0 && isAlive)
                Dead();

            onPlayerLifeChanges?.Invoke(currentLife, myLife);
            isStuned = true;
            
            myMovment.ReBounce(point);
            StartCoroutine(LoseControl());
        }

        public void Dead()
        {
            Debug.Log("Player dead");
            
            currentLife = 0;
            isAlive = false;

            myMesh.SetActive(false);

            onPlayerDeath?.Invoke(this);
            DisablePlayer();

            Invoke(nameof(EndGame), 1f);
        }

        public void EndGame()
        {
            LevelManager.Instance.Lose();
        }

        private void DisablePlayer()
        {
            //gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
            myMovment.enabled = false;
            myMovment.Stop();
            Camera.main.GetComponent<CameraFollowPlayer>().CancelFollow();
            //this.enabled = false;
        }

        public void Stun() => isStuned = true;

        IEnumerator LoseControl()
        {
            yield return new WaitForSeconds(timeToStunRecover);
            isStuned = false;
        }
    }
}

