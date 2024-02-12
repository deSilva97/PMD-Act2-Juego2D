using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] EntityShoes shoes;
    [Space]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpStrenght = 12;
    [SerializeField] float gravityMultiplier = 2;
    [SerializeField] int numberJumps = 1;    

    Rigidbody2D rb;
    //SpriteRenderer spr;
    BoxCollider2D coll;

    public float xMove, yMove;
    int currentJump;

    const float MAX_GRAVITY = 9.8f;
    const float DISTANCE_TO_RECOVER_COLLISIONS = -1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //spr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        currentJump = numberJumps;
        rb.gravityScale = 0;
    }

    public void Move()
    {
        xMove = horizontalMove();
        yMove = verticalMove(yMove);
        rb.velocity = new Vector2(xMove, yMove);

        if (yMove < DISTANCE_TO_RECOVER_COLLISIONS)
        {
            shoes.Able();
            coll.isTrigger = false;
        }
        else
        {
            coll.isTrigger = true;
        }
    }

    private float horizontalMove()
    {
        float value = Input.GetAxisRaw("Horizontal");

        if (value < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            //spr.flipX = true;
            //shoes.transform.localPosition = new Vector3(.1f, 0, 0);
        }
        else if (value > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            //spr.flipX = false;
            shoes.transform.localPosition = new Vector3(-.1f, 0, 0);
        }

        return Input.GetAxisRaw("Horizontal") * moveSpeed;
    }
    private float verticalMove(float value)
    {

        if (!shoes.isLanding)
        {
            //shoes.setActive(yMove > 0 ? false: true);


            if (value > -MAX_GRAVITY)
                value -= Time.deltaTime * MAX_GRAVITY * gravityMultiplier;
        }
        else
        {
            value = 0; //Devolver a su estado original la posible gravedad negativa
        }

        return value;
    }

    public void Jump()
    {
        if (/*Input.GetKeyDown(KeyCode.Space) &&*/ currentJump > 0 && shoes.isLanding)
        {
            yMove = jumpStrenght;
            shoes.Disable();
        }
    }

}
