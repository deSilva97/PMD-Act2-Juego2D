using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] FollowTarget followTarget;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followTarget.target = collision.transform;
            PickUp();
        }
    }

    private void Update()
    {
        if (followTarget.target == null)
            return;
        
        int xDirection = (int)followTarget.target.localScale.x;
        if (followTarget.target.localScale.x < 0)
            xDirection = -1;
        else if (followTarget.target.localScale.x > 0)
            xDirection = 1;

        followTarget.SetDirectionOffset(xDirection, 1);
        
    }

    public new void PickUp()
    {
        GetComponent<Collider2D>().enabled = false;
        audioSource.Play();

        PlayerManager.Instance.setKey(true);
    }
}
