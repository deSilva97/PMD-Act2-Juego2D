using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] string[] detectTag;    

    private List<IDamageable> damageables;

    public System.Action onEntityAttack;

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
        if (DetectOneOfTheTags(collision.tag))
        {
            IDamageable d = collision.GetComponent<IDamageable>();
            if (d != null)
                damageables.Add(d);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (DetectOneOfTheTags(collision.tag))
        {
            IDamageable d = collision.GetComponent<IDamageable>();
            if (d != null)
                damageables.Remove(d);
        }
    }

    public void SetDamageToList(int damage)
    {
        onEntityAttack?.Invoke();

        for (int i = 0; i < damageables.Count; i++)
        {
            damageables[i].SetDamage(damage);
        }

    }

    private bool DetectOneOfTheTags(string tag)
    {
        foreach (string str in detectTag)
            if (str == tag)
                return true;
        return false;
    }
}
