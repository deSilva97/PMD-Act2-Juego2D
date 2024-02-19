using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    [SerializeField] CharacterShoes shoes;
    [Space]
    
    float moveSpeed = 10;
    float jumpStrength = 12;
    float gravityMultiplier = 2;

    int currentJump;

    public Rigidbody2D myRigidbody { get; private set; }

    float xMove, yMove;

    const float MAX_GRAVITY = 9.8f;

    public System.Action onEntityJump;

    [SerializeField] LayerMask raycastLayerMask;
    [SerializeField] float raycastDistance = .5f;

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void SetJumpStrength(float value)
    {
        jumpStrength = value;
    }


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        myRigidbody.gravityScale = 1;
        currentJump = 1;
    }

    public void Move(float horizontalAxis, float multiplier = 1)
    {
        if (horizontalAxis != 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(shoes.transform.position, Vector2.right * horizontalAxis, raycastDistance, raycastLayerMask);
            if (hit.collider != null)
            {
                // Aquí puedes hacer cualquier otra acción cuando hay un choque, por ejemplo, imprimir el nombre del objeto chocado.
                Debug.Log("Collision with: " + hit.collider.gameObject.name);

                // Establecer xMove a 0 si hay un choque.
                xMove = 0f;
            }
            else
            {
                // Si no hay choque, calcular el movimiento normalmente.
                xMove = horizontalMove(horizontalAxis) * multiplier;
            }
        }
        else
        {
            xMove = 0f;
        }

        yMove = verticalMove(yMove);

        myRigidbody.velocity = new Vector2(xMove, yMove);

        /*
        xMove = horizontalMove(horizontalAxis) * multiplier;
        yMove = verticalMove(yMove);

        myRigidbody.velocity = new Vector2(xMove,  yMove);
        */
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

    public void TryJump()
    {
        if (currentJump > 0 && shoes.isLanding)
        {
            currentJump--;
            StartJump(jumpStrength);
        }
    }

    public void StartJump(float force)
    {
        yMove = force;
        shoes.ForeceLandOff();
        onEntityJump?.Invoke();

    }

    public void StopJump()
    {
        yMove = 0;
    }
}
