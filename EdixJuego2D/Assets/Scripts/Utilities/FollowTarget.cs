using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    [Space]
    [SerializeField] float speed = 1;
    [SerializeField] Vector2 offset;
    [SerializeField] float minDistanceStop = .5f;

    private Vector2 directionOffset;
    private Vector3 currentPosition;

    private void Start()
    {
        directionOffset = Vector2.one;
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector2 targetPosition = target.position;
        Vector2 myPosition = transform.position;              

        if (Vector2.Distance(targetPosition, myPosition) > minDistanceStop)
            currentPosition = Vector2.Lerp(myPosition , targetPosition + (offset * directionOffset), speed * Time.deltaTime);

        transform.position = currentPosition;
    }
    
    public void SetDirectionOffset(int x, int y) => directionOffset = new Vector2(x, y);

}
