using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : Spawner
{
    [SerializeField] Transform[] points;

    protected override void Spawn()
    {
        base.Spawn();

        MoveTowardPoints movemnt = myList[myList.Count - 1].GetComponent<MoveTowardPoints>();
        movemnt.SetPatrol(points);
    }
}
