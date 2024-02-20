using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public abstract class Pickeable : MonoBehaviour
{

    protected Collider2D coll;
    protected AudioSource source;
    protected SpriteRenderer spr;

    protected Sprite sp;

    protected void Awake()
    {
        coll = GetComponent<Collider2D>();
        source = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
    }

    protected void Start()
    {
        sp = spr.sprite;
        Restart();
    }

    public void Restart()
    {
        coll.enabled = true;
        spr.sprite = sp;
    }

    public void PickUp()
    {
        coll.enabled = false;        
        spr.sprite = null;

        source.Play();
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
