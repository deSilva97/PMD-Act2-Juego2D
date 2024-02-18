using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    [SerializeField] EnemyController controller;
    [SerializeField] float raycastDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float timeTryClimb = 1f;    

    float timer;

    private void Start()
    {
        timer = timeTryClimb;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0)
            return;

        timer = timeTryClimb;

        Vector2 origin = transform.position;
        Vector2 direction = transform.right * controller.transform.localScale.x; // Derecha relativa al objeto

        // Lanza el rayo en la dirección hacia delante
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, raycastDistance, layerMask);

        Debug.DrawLine(origin, origin + direction * raycastDistance, Color.red, 1f);

        // Si el rayo golpea algo
        if (hit.collider != null)
        {
            controller.Climb();
        }
        else controller.StopClimb();
    }
}
