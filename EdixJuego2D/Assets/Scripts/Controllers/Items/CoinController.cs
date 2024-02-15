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
        PlayerManager.Instance.setCoins(PlayerManager.Instance.getCoins() + value);
    }
}
