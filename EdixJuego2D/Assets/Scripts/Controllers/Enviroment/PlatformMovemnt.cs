using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlatformMovemnt : MonoBehaviour
{

    [SerializeField] Transform[] points;
    [SerializeField] float timeAtPoint = 2;
    [SerializeField] float moveSpeed = 5;

    Vector3 direction;
    int index;

    float timer;

    private void Start()
    {
        ChangeDirection();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        //timer = timeAtPoint;

        transform.Translate(direction * Time.deltaTime * moveSpeed);

        //transform.position = points[index].position;

        if (Vector3.Distance(points[index].position, transform.position) < .2f)
        {
            ChangeDirection();
        }


    }

    int NextInt(int index)
    {
        int nextIndex = index + 1;
        if (nextIndex >= points.Length)
            nextIndex = 0;
        return nextIndex;
    }

    private void ChangeDirection()
    {
        transform.position = points[index].position;
        timer = timeAtPoint;

        int nextIndex = NextInt(index);
        direction = (points[nextIndex].position - points[index].position).normalized;

        index = nextIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EntityMovement instance = collision.collider.GetComponent<EntityMovement>();
        if (instance != null)
            instance.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider != null)
            collision.transform.parent = null;
    }

    private void OnDrawGizmosSelected()
    {
        if (points == null)
            return;

        for(int i = 0; i < points.Length; i++)
        {

            Gizmos.DrawLine(points[i].position, points[NextInt(i)].position);
        }
    }
}
