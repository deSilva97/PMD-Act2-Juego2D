using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    [SerializeField] EnemyController controller;
    
    bool canClimb = true;
    float timerNextTry = 1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canClimb)
            return;

        if (collision.tag.Equals("Platform") || collision.tag.Equals("Obstacle"))
        {
            controller.Climb();
            StartCoroutine(Reload());

        }
    }

    IEnumerator Reload()
    {
        canClimb = false;
        yield return new WaitForSeconds(timerNextTry);
        canClimb = true;
    }
}
