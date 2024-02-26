using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IKilleable target = collision.GetComponent<IKilleable>();
        if (target != null)
            target.Dead();
    }
}
