using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    [SerializeField] string detectTag = "tag";
    [SerializeField] KeyCode inputKey = KeyCode.X;

    private List<IDamageable> damageables;

    public KeyCode getInputkey() => inputKey;


    private void Start()
    {
        damageables = new List<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == detectTag)
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
        for(int i = 0; i < damageables.Count; i++)
        {
            damageables[i].SetDamage(damage);
        }

    }
}

