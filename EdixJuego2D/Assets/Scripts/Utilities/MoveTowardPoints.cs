using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPoints : MonoBehaviour
{
    public event System.Action<Vector2, Vector2> onChangeDirection;

    [SerializeField] Transform[] startPoints;
    
    [SerializeField] float timeAtPoint = 2;
    [SerializeField] float moveSpeed = 5;

    Vector2[] points;

    int index;

    float timer;

    public void SetMoveSpeed(float value) => moveSpeed = value;
    
    public int Index { get => index; }

    public void SetPatrol(Transform[] points) => startPoints = points;

    public void SetPoints(Transform[] points)
    {
        this.points = new Vector2[points.Length];
        for (int i = 0; i < points.Length; i++)
            this.points[i] = points[i].position;
    }

    private void Start()
    {
        SetPoints(startPoints);
    }

    private void Update()
    {
        if (points.Length < 1)
            return;

        if (timer > 0 )
        {
            timer -= Time.deltaTime;
            return;
        }

        //timer = timeAtPoint;

        transform.position = Vector2.MoveTowards(transform.position, points[index], moveSpeed * Time.deltaTime);
        //transform.Translate(direction * Time.deltaTime * moveSpeed);
        //transform.position = points[index].position;

        if (Vector3.Distance(points[index], transform.position) < .1f)
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
        transform.position = points[index];
        timer = timeAtPoint;

        int nextIndex = NextInt(index);

        onChangeDirection?.Invoke(points[index], points[nextIndex]);

        index = nextIndex;
    }
}
