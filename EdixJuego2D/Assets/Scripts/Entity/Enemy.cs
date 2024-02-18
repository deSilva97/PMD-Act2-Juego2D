using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField][Min(1)] private int health;
    [SerializeField][Min(0)] private float moveSpeed;
    [SerializeField][Min(0)] private float jumpStrength;
    [SerializeField][Min(0)] private float intervalAttack;
    [SerializeField][Min(0)] private int damage;
    [Space]
    [SerializeField][Min(0)] private int points;

    public int Health { get => health; }
    public float MoveSpeed { get => moveSpeed; }
    public float JumpStrength { get => jumpStrength; }
    public float IntervalAttack { get => intervalAttack; }
    public int Damage { get => damage; }

    public int Points { get => points; }
}
