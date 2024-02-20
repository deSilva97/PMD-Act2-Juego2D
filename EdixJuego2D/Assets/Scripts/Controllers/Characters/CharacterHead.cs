using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHead : MonoBehaviour
{
    [SerializeField] CharacterMovment myMovment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crossable"))
        {
            Debug.Log("Cabeza: Objeto atravesable");
        }
        else
        {
            myMovment.StopJump();

        }
    }
}
