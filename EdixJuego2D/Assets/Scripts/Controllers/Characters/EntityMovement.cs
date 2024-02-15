using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] EntityShoes shoes;
    [Space]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpStrenght = 12;
    [SerializeField] float gravityMultiplier = 2;

    int currentJump;

    public Rigidbody2D myRigidbody { get; private set; }

    float xMove, yMove;

    const float MAX_GRAVITY = 9.8f;

    public System.Action onEntityJump;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        myRigidbody.gravityScale = 1;
        currentJump = 1;
    }

    public void Move(float horizontalAxis)
    {
        xMove = horizontalMove(horizontalAxis);
        yMove = verticalMove(yMove);
        myRigidbody.velocity = new Vector2(xMove,  yMove);
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
            currentJump = 1;
            value = -myRigidbody.gravityScale; //Devolver a su estado original la posible gravedad negativa
        }

        return value;
    }

    public void Jump()
    {
        if (currentJump > 0 && shoes.isLanding)
        {
            currentJump--;
            yMove = jumpStrenght;
            shoes.ForeceLandOff();
            onEntityJump?.Invoke();
        }
    }

}
