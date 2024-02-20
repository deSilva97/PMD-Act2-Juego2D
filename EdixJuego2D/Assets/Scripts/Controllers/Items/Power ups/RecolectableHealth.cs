using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Animations;

public class RecolectableHealth : Pickeable
{
    [SerializeField] int points = 100;
    [SerializeField] int healthRestore = 10;

    CodeAnimation anim;

    protected new void Awake()
    {
        base.Awake();
        anim = GetComponent<CodeAnimation>();
    }

    protected new void Start()
    {
        base.Start();
        anim.Play();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
            Debug.Log("hit");
        if (player != null)
        {
            Debug.Log("Player hit");
            player.SetLife(player.currentLife + healthRestore);
            LevelManager.Instance.AddPoints(points);
            anim.Stop();
            PickUp();
        }
    }

}
