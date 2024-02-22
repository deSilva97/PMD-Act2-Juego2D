using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject mesh;
    [SerializeField] Collider2D noTriggerCollider;

    [Header("Breakable")]
    [SerializeField] float timeToBreak;
    [SerializeField] float timeToRecover;
    [SerializeField] BreakablePlatform node;

    float timer;
    Transform target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("coll: " + collision.collider.name);
        if (collision.collider.CompareTag("Player"))
        {
            target = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
            timer = timeToBreak;
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                Break();
        }

    }

    void SetUp(bool active)
    {
        mesh.gameObject.SetActive(active);
        noTriggerCollider.enabled = active;
    }

    private void Break()
    {
        timer = timeToBreak;
        target = null;

        if (node != null)
            node.Break();

        audioSource.Play();

        Invoke(nameof(Recover), timeToRecover);

        SetUp(false);
    }

    private void Recover()
    {
        SetUp(true);
    }
}
