using System.Collections;
using UnityEngine;

public class PowerUpController : Pickeable
{
    public event System.Action onPickUp;
    [SerializeField] [Min(-1)] float timeToRecover = 10f;

    public new void PickUp()
    {
        base.PickUp();
        onPickUp?.Invoke();
        if(timeToRecover >= 0)
            Invoke(nameof(Restart), timeToRecover);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PickUp();
    }
}
