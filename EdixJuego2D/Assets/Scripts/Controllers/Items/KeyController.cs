using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Pickeable
{
    [SerializeField] FollowTarget followTarget;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null)
            followTarget.target = collision.transform;

        PickUp();
    }

    private void Update()
    {
        if (followTarget.target == null)
            return;
        
        Debug.Log("Activando key anim");

        int xDirection = (int)followTarget.target.localScale.x;
        if (followTarget.target.localScale.x < 0)
            xDirection = -1;
        else if (followTarget.target.localScale.x > 0)
            xDirection = 1;

        followTarget.SetDirectionOffset(xDirection, 1);
        
    }

    public void PickUp()
    {
        base.PickUp(false, sp);        
        PlayerManager.Instance.setKey(true);
    }
}
