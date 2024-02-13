using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] EntityShoes shoes;
    [Space]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpStrenght = 12;
    [SerializeField] float gravityMultiplier = 2;
    [SerializeField] int numberJumps = 1;

    Rigidbody2D rb;
    BoxCollider2D coll;

    public float xMove, yMove;
    int currentJump;

    const float MAX_GRAVITY = 9.8f;
    const float DISTANCE_TO_RECOVER_COLLISIONS = -1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        currentJump = numberJumps;
        rb.gravityScale = 1;
    }

    public void Move(float horizontalAxis)
    {
        xMove = horizontalMove(horizontalAxis);
        yMove = verticalMove(yMove);
        rb.velocity = new Vector2(xMove,  yMove);
    }

    private float horizontalMove(float value)
    {
        if (value < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (value > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        return value * moveSpeed;
    }
    private float verticalMove(float value)
    {

        if (!shoes.isLanding)
        {
            if (value > -MAX_GRAVITY)
                value -= Time.deltaTime * MAX_GRAVITY * gravityMultiplier;
        }
        else
        {
            value = -rb.gravityScale; //Devolver a su estado original la posible gravedad negativa
        }

        return value;
    }

    public void Jump()
    {
        if (currentJump > 0 && shoes.isLanding)
        {
            yMove = jumpStrenght;
            shoes.ForeceLandOff();
        }
    }

}
