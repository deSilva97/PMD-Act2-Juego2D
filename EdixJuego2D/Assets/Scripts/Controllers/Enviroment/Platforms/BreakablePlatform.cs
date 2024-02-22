using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public event Action<float, float> onBreak;

    [Header("References")]
    [SerializeField] GameObject mesh;
    AudioSource audioSource;
    Collider2D[] colliders;

    [Header("Breakable")]
    [SerializeField] float timeToBreak;
    [SerializeField] float timeToRecover;
    [SerializeField] bool cancelable;
    [SerializeField] bool isBreaked;
    [SerializeField] bool isRecovering;

    [Header("Audio")]
    [SerializeField] AudioClip clipCollision;
    [SerializeField] AudioClip clipBreak;

    [Header("Nodes")]
    [SerializeField] int id;
    [SerializeField] BreakablePlatform linkedNode;
    [SerializeField] float timeExtraToNode;


    float timer;
    Transform target;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        colliders = GetComponents<Collider2D>();
    }

    private void Start()
    {
        if (linkedNode != null)
            linkedNode.onBreak += (a, b) => Break(a, b + timeExtraToNode);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(target == null)
            {
               target = collision.transform;
               PlayAudio(clipCollision);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(cancelable)
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
                Break(timeToBreak, timeToRecover);
        }

    }

    void SetUp(bool active)
    {
        isBreaked = !active;

        mesh.SetActive (active);

        for(int i = 0;i<colliders.Length; i++)
        {
            colliders[i].enabled = active;
        }
            
    }

    public void Break(float timeToBreak, float timeToRecover)
    {
        timer = timeToBreak;
        target = null;

        PlayAudio(clipBreak);

        onBreak?.Invoke(timeToBreak, timeToRecover);

        StartCoroutine(Recover(timeToRecover));

        SetUp(false);
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator Recover(float timeToRecover)
    {
        isRecovering = true;

        yield return new WaitForSeconds(timeToRecover);

        if(linkedNode != null)
        {
            while (linkedNode.isRecovering)
            {
                Debug.Log(gameObject.name + " esta esperando a " + linkedNode.name);
                yield return new WaitForEndOfFrame();

            }

            yield return new WaitForSeconds(timeExtraToNode);

        }

        SetUp(true);
        isRecovering = false;
    }
}
