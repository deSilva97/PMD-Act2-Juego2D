using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovment : MonoBehaviour
{
    [Header("Movment")]
    [SerializeField] protected float moveSpeed;
    public bool canMove { get; set; }

    public float SetMoveSpeed(float value) => moveSpeed = value;
}
