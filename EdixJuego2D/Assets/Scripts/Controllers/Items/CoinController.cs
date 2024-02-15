using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, IPickeable
{
    [SerializeField] int value = 1;

    Collider2D coll;
    AudioSource source;
    SpriteRenderer spr;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        source = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pick();
    }

    public void pick()
    {

        coll.enabled = false; 
        source.Play();
        spr.sprite = null;
        
        PlayerManager.Instance.setCoins(PlayerManager.Instance.getCoins() + value);
    }
}
