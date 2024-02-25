using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentSimple : EnemyMovment
{
    Vector2 direction;

    [Header("Face")]
    [SerializeField] Transform face;
    [SerializeField] Vector3 faceDimension;
    [SerializeField] LayerMask faceMask;
    [SerializeField] bool isFacing;


    private void Start()
    {
        direction = transform.localScale;
    }

    private void Update()
    {
        
        if (!canMove)
        {
            isFacing = false;
            return;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        isFacing = Physics2D.OverlapBox(face.position, faceDimension, 0f, faceMask);

        if (isFacing)
        {
            ChangeDirection();
            isFacing = false;
        }
    }

    private void ChangeDirection()
    {
        direction.x *= -1;
        transform.localScale = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(face.position, faceDimension);
    }

}
