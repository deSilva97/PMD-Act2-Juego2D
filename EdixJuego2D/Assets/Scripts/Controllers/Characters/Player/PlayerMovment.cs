using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Plataformer {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovment : MonoBehaviour
    {
        [Header("References")]
        private Rigidbody2D rb2d;
        private BoxCollider2D coll;

        [Header("Inputs")]
        private float movmentInput;
        private bool jumpInput;

        [Header("Movment")]
        float horizontalMovment;
        [SerializeField] float horizontalSpeed;
        [SerializeField] float movmentSmooth;

        Vector3 speed = Vector3.zero;

        bool lookingRight = true;

        [Header("Jump")]
        [SerializeField] float jumpStrenght;
        [SerializeField] [Min(1)] int numberJumps;
        [SerializeField] LayerMask shoesMask;
        [SerializeField] Transform shoes;
        [SerializeField] Vector3 shoesDimension;
        [SerializeField] bool isGrounded;

        int currentJumps;

        private bool jumping;

        [Header("Face")]
        [SerializeField] Transform face;
        [SerializeField] Vector3 faceDimension;
        [SerializeField] LayerMask faceMask;
        [SerializeField] bool isFacing;

        [Header("Head")]
        [SerializeField] Transform head;
        [SerializeField] Vector3 headDimension;
        [SerializeField] LayerMask headMask;
        [SerializeField] bool isHeading;

        private bool isFalling;

        public void SetMovmentInput(float inputValue) => movmentInput = inputValue * horizontalSpeed;
        public void SetJumpInput(bool condition) => jumpInput = condition;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            coll = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
           //currentJumps = numberJumps;
        }

        private void Update()
        {
            //Si hay algún controlador android se puede eliminar estos dos elementos
            SetMovmentInput(Input.GetAxisRaw("Horizontal"));
            SetJumpInput(Input.GetButtonDown("Jump"));

            horizontalMovment = movmentInput * horizontalSpeed;
            if (jumpInput)
                jumping = true;

         
        }

        private void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapBox(shoes.position, shoesDimension, 0f, shoesMask);

            isFacing = Physics2D.OverlapBox(face.position, faceDimension, 0f, faceMask);

            isHeading = Physics2D.OverlapBox(head.position, headDimension, 0f, headMask);

            Move(horizontalMovment * Time.deltaTime, rb2d.velocity.y, jumping);

            jumping = false;

        }

        private void Move(float x, float y, bool jump)
        {
            if (x > 0 && !lookingRight)
                TurnAround();
            else if (x < 0 && lookingRight)
                TurnAround();

            if (isHeading && !isFalling)
            {
                Debug.Log("Head touch");
                y = 0;
                rb2d.AddForce(new Vector2(0, -jumpStrenght), ForceMode2D.Impulse);
                isFalling = true;
                isHeading = false;
            }

            if (isFacing)
                x = 0;

            Vector3 objectSpeed = new Vector2(x, y);
            rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, objectSpeed, ref speed, movmentSmooth);

            if (isGrounded)
            {
                isFalling = false;
                currentJumps = numberJumps;
            }
                
            if(currentJumps > 0 && jumping)
            {
                Debug.Log("Jump");
                currentJumps--;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                isGrounded = false;
                rb2d.AddForce(Vector2.up * jumpStrenght, ForceMode2D.Impulse);

            }
        }

        private void TurnAround()
        {
            lookingRight = !lookingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red; 
            Gizmos.DrawWireCube(shoes.position, shoesDimension);
            Gizmos.color = Color.blue; 
            Gizmos.DrawWireCube(face.position, faceDimension);
            Gizmos.color = Color.green; 
            Gizmos.DrawWireCube(head.position, headDimension);
        }
    }

}

