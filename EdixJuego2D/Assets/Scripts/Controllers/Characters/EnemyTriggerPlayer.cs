using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerPlayer : MonoBehaviour
{
    [SerializeField] EnemyController controller;
    [SerializeField] string triggerTag = "Player";
    [Space]
    [SerializeField] float triggerRange = 5f;
    [SerializeField] float lostRange = 10f;
    
    bool following;

    public Transform target { get; private set; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerTag))
        {
            target = collision.transform;
        }
    }


    private void Update()
    {
        if (target == null)
            return;

        if (Vector3.Distance(target.position, transform.position) > lostRange)
            target = null;
    }
}
