using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] string detectTag = "tag";    

    private List<IDamageable> damageables;

    private void Start()
    {
        damageables = new List<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == detectTag)
        {
            IDamageable d = collision.GetComponent<IDamageable>();
            if (d != null)
                damageables.Add(d);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == detectTag)
        {
            IDamageable d = collision.GetComponent<IDamageable>();
            if (d != null)
                damageables.Remove(d);
        }
    }

    public void SetDamageToList(int damage)
    {
        foreach (IDamageable d in damageables)
        {
            Debug.Log("Haciendo da�o a " + d);
            d.SetDamage(damage);
        }

    }
}
