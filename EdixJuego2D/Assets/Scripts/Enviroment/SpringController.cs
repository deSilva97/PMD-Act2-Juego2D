using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] float strenght = 15;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IBounceable controller = collision.GetComponent<IBounceable>();
        if (controller != null)
        {
            anim.SetTrigger("action");
            controller.Bounce(Vector2.up, strenght);
        }
    }
}
