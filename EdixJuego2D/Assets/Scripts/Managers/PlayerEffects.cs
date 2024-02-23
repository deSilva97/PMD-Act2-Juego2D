using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [Header("Particles")]
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ParticleSystem hit;

    private void Start()
    {
        player.onPlayerDeath += ExplosionPlayer;
        player.onPlayerHit += HitPlayer;
    }

    private void OnApplicationQuit()
    {
        player.onPlayerDeath -= ExplosionPlayer;
        player.onPlayerHit -= HitPlayer;
    }

    private void ExplosionPlayer(PlayerController p) => PlayEffect(explosion, p.transform.position);
    private void HitPlayer(PlayerController p, Vector2 point)
    {
        float xScale = (((Vector2)p.transform.position - point).magnitude) > 0 ? hit.transform.localScale.x : -hit.transform.localScale.x;
        Vector3 scale = hit.transform.localScale;
        scale.x = xScale;
        hit.transform.localScale = scale;

        PlayEffect(hit, p.transform.position);
    }

    private void PlayEffect(ParticleSystem particle, Vector2 position)
    {
        particle.transform.position = position;
        particle.Play();
    }
}
