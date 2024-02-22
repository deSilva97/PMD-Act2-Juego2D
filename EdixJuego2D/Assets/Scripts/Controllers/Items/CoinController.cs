using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinController : Pickeable
{
    [SerializeField] int value = 1;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp();
    }

    public new void PickUp()
    {
        base.PickUp();
        LevelManager.Instance.AddPoints(value);
        GetComponent<Animator>().enabled = false;
    }
}
