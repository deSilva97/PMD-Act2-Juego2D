using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Pickeable
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp();
    }

    public new void PickUp()
    {
        base.PickUp();        
        PlayerManager.Instance.setKey(true);
    }
}
