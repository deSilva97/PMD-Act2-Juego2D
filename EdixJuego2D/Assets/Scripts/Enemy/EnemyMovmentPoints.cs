using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveTowardPoints))]
public class EnemyMovmentPoints : EnemyMovment
{
    [Header("References")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform[] startPoints;
    Vector2[] points;
    int index;
    float savedMoveSpeed;

    [Header("Timer")]
    [SerializeField] float timeAtPoint = 2;
    float timer;


    private void Start()
    {
        savedMoveSpeed = moveSpeed;
        SetPoints(startPoints);
    }

    public void Stop() => SetMoveSpeed(0);
    public void Resume() => SetMoveSpeed(savedMoveSpeed);

    private void Update()
    {
        if (points.Length < 1)
            return;

        if (canMove)
            Resume();
        else Stop();

        if (timer > 0)
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

    private void SetLookDirection(Vector2 from, Vector2 to)
    {
        bool value = false;
        if ((to.x - from.x) > 0)
            value = true;

        spriteRenderer.flipX = value;
    }

    public void SetPatrol(Transform[] points) => startPoints = points;

    public void SetPoints(Transform[] points)
    {
        this.points = new Vector2[points.Length];
        for (int i = 0; i < points.Length; i++)
            this.points[i] = points[i].position;
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
        SetLookDirection(points[index], points[nextIndex]);

        index = nextIndex;
    }
}
