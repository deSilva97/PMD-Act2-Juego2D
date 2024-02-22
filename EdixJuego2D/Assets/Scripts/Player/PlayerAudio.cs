using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerAudio : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] PlayerController playerController;
        [SerializeField] PlayerMovment playerMovment;
        AudioSource audioSource;

        [Header("Audio")]
        [SerializeField] AudioClip onJump;
        [SerializeField] AudioClip onDamaged;
        [SerializeField] AudioClip onHeadHit;
        [SerializeField] AudioClip onShoesHit;


        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            audioSource.playOnAwake = false; 
            audioSource.loop = false;

            playerController.onPlayerHit += PlayHit;

            playerMovment.onPlayerJump += PlayJump;
            playerMovment.onPlayerHitHead += PlayHitHead;
        }

        private void PlayHit() => Play(onHeadHit);

        private void PlayJump() => Play(onJump);
        private void PlayHitHead() => Play(onHeadHit);

        public void Play(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        private void OnApplicationQuit()
        {
            playerController.onPlayerHit -= PlayHit;

            playerMovment.onPlayerJump -= PlayJump;
            playerMovment.onPlayerHitHead -= PlayHitHead;

        }
    }
}
