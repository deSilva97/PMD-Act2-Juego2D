using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField][Min(1)] private int health;
    [SerializeField][Min(0)] private float moveSpeed;
    [SerializeField][Min(0)] private float jumpStrength;
    [SerializeField][Min(0)] private float intervalAttack;
    [SerializeField][Min(0)] private int damage;
    [SerializeField][Min(0)] private int points;

    // Getters para acceder a las propiedades privadas
    public int Health
    {
        get { return health; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public float JumpStrength
    {
        get { return jumpStrength; }
    }

    public float IntervalAttack
    {
        get { return intervalAttack; }
    }

    public int Damage
    {
        get { return damage; }
    }

    public int Points
    {
        get { return points; }
    }
}
