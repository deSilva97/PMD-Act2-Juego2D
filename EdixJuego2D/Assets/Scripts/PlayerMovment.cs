using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerShoes shoes;
    [Space]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpStrenght = 12;
    [SerializeField] float gravityMultiplier = 2;
    [SerializeField] int numberJumps = 1;    

    Rigidbody2D rb;
    SpriteRenderer spr;
    BoxCollider2D coll;

    public float xMove, yMove;
    int currentJump;

    const float MAX_GRAVITY = 9.8f;
    const float DISTANCE_TO_RECOVER_COLLISIONS = -1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        currentJump = numberJumps;
        rb.gravityScale = 0;
    }

    private void Update()
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
            spr.flipX = true;
        else if(value > 0) 
            spr.flipX = false;

        return Input.GetAxisRaw("Horizontal") * moveSpeed;
    }
    private float verticalMove(float value)
    {

        if (Input.GetKeyDown(KeyCode.Space) && currentJump > 0 && shoes.isLanding)
        {
            value = jumpStrenght;
            shoes.Disable();
        }

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

}
