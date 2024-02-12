using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityShoes : MonoBehaviour
{
    public bool isLanding { get; private set; }

    CircleCollider2D coll;

    Collider2D currentColliderTrigger;

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

        //Permite, al atravesar Triggers, corregir el contacto con el Collider en el que se encuentra
        if (currentColliderTrigger != null)
        {
            currentColliderTrigger = null;
            isLanding = true;
        }
            
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isLanding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isLanding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        currentColliderTrigger = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentColliderTrigger = null;
    }
}
