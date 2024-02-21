using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Player
{
    public class RegulableJump : MonoBehaviour
    {
        [Header("References")]
        private Rigidbody2D rb2d;

        [Header("Jump")]
        [SerializeField] float jumpStrenght;
        [SerializeField] Transform shoesController;
        [SerializeField] Vector2 boxDimension;
        [SerializeField] LayerMask whatIsGround;

        public bool isGrounded { get; private set; }

        bool isJumping;

        [Header("Regulable Jump")]
        [SerializeField][Range(0, 1)] float multiplierCancelJump;
        [SerializeField] float multiplierGravity;
        float gravityScale;

        bool pressedJumpButton = true;


        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            
        }

        private void Start()
        {
            gravityScale = rb2d.gravityScale;
        }

        private void Update()
        {
            if (Input.GetButton("Jump"))
                isJumping = true;

            if (Input.GetButtonUp("Jump"))
                PressJumpButton();

            isGrounded = Physics2D.OverlapBox(shoesController.position, boxDimension, 0, whatIsGround);
        }

 

        private void FixedUpdate()
        {
            if (isJumping && pressedJumpButton && isGrounded)
                Jump(jumpStrenght);

            if (rb2d.velocity.y < 0 && !isGrounded)
                rb2d.gravityScale = gravityScale * multiplierGravity;
            else
                rb2d.gravityScale = gravityScale;

            isJumping = false;
        }

        private void Jump(float strenght)
        {
            rb2d.AddForce(Vector2.up * strenght, ForceMode2D.Impulse);
            isGrounded = false;
        }

        private void PressJumpButton()
        {
            if (rb2d.velocity.y > 0)
                rb2d.AddForce(Vector2.down * rb2d.velocity.y * (1 - multiplierCancelJump), ForceMode2D.Impulse);

            pressedJumpButton = true;
            isJumping = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(shoesController.position, boxDimension);
        }
    }
}

