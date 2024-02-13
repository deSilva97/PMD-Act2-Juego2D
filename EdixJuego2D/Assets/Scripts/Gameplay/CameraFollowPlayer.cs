using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector2 xLimits;
    [SerializeField] Vector2 yLimits;
    [Space]
    [SerializeField] float speed = 1;
    [SerializeField] float offsetHorizontal = 1.25f;
    [SerializeField] float offsetVertical = 1.5f;
    [SerializeField] float minDistanceStop = .5f;

    Vector3 position;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        if (Vector3.Distance(getTargetPosition(), transform.position) > minDistanceStop)
            position = Vector3.Lerp(transform.position, getTargetPosition() + getRelativePosition(), speed * Time.deltaTime);

        position.x = Mathf.Clamp(position.x, xLimits.x, xLimits.y);
        position.y = Mathf.Clamp(position.y, yLimits.x, yLimits.y);
        position.z = -10;

        transform.position = position;
    }

    private void LateUpdate()
    {
      
    }

    Vector3 getRelativePosition()
    {
        Vector3 offset = new Vector3(target.localScale.x * offsetHorizontal, offsetVertical, 0);
        return offset;
    }

    Vector3 getTargetPosition()
    {
        Vector3 pos = target.transform.position;
        pos.z = transform.position.z;
        return pos;
    }

}
