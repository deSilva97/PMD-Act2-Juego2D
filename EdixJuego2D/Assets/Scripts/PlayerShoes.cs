using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoes : MonoBehaviour
{

    public bool isLanding { get; private set; }

    CircleCollider2D coll;

    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
    }

    public void Disable()
    {
        coll.isTrigger = true;
        isLanding = false;
    }

    public void Able()
    {
        coll.isTrigger = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Los pies han golpeado a " + collision.gameObject.name);
        isLanding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isLanding = false;
    }
}
