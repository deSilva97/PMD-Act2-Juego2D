using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] string detectTag = "tag";    

    private List<IDamageable> damageables;

    public bool canAttack()
    {
        if (damageables.Count > 0)
            return true;
        else return false;
    }

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
        for (int i = 0; i < damageables.Count; i++)
        {
            damageables[i].SetDamage(damage);
        }

    }
}
