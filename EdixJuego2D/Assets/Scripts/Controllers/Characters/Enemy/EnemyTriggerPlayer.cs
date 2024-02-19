using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerPlayer : MonoBehaviour
{
    [SerializeField] EnemyControllerOld controller;
    [SerializeField] string triggerTag = "Player";
    [Space]
    [SerializeField] float triggerRange = 5f;
    [SerializeField] float lostRange = 10f;

    PlayerController player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }
    private void Update()
    {
        if (controller.target == null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < triggerRange)
                controller.EnemyAtRange(player.transform);
        }
        else
        {
            if (Vector3.Distance(controller.target.transform.position, transform.position) > lostRange)
                controller.target = null;
        }
          
    }
}
