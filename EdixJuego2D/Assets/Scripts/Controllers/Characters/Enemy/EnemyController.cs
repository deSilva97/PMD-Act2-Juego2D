using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerEnemy myLife;
    [SerializeField] EnemyMovmentSimple myMovment;


    private void Update()
    {
        myMovment.canMove = !myLife.isStuned;
        Debug.Log(myMovment.canMove);
    }
}
