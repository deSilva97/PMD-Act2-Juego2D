using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpStrenght = 12;
    [SerializeField] float gravityMultiplier = 2;
    [SerializeField] int numberJumps = 1;

    [SerializeField] bool isLanding = false;

    Rigidbody2D rb;

    public float xMove, yMove;
    int currentJump;

    const float MAX_GRAVITY = 9.8f;
    const float gravityScale = 9.8f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    private float horizontalMove()
    {
        return Input.GetAxisRaw("Horizontal") * moveSpeed;
    }
    private float verticalMove(float value)
    {

        if (!isLanding)
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentJump > 0)
            {
                value = jumpStrenght;
            }

            if (value > -MAX_GRAVITY)
                value -= Time.deltaTime * gravityScale * gravityMultiplier;
        }
        else
        {
            value = 0;
        }

        return value;
    }

}
