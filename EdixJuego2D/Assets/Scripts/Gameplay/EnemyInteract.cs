using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    [SerializeField] EnemyController controller;
    
    bool canClimb = true;
    [SerializeField] float timeTryClimb = 1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canClimb)
            return;

        if (collision.tag.Equals("Ground") || collision.tag.Equals("Obstacle") || collision.tag.Equals("Platform"))
        {
            controller.Climb();
            StartCoroutine(Reload());

        }
    }

    IEnumerator Reload()
    {
        canClimb = false;
        yield return new WaitForSeconds(timeTryClimb);
        canClimb = true;
    }
}
