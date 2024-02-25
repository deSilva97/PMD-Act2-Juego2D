using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField][Min(1)] private int health;
    [SerializeField][Min(0)] private int damage;
    [Space]
    [SerializeField][Min(0)] private float moveSpeed;
    [SerializeField][Min(0)] private float timeStuned;
    [Space]
    [SerializeField][Min(0)] private int points;

    public int Health { get => health; }
    public float MoveSpeed { get => moveSpeed; }
    public float TimeStuned { get => timeStuned; }
    public int Damage { get => damage; }

    public int Points { get => points; }
}
