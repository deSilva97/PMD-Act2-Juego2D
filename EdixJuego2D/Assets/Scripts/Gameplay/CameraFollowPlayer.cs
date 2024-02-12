using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [Space]
    [SerializeField] float speed = 1;
    [SerializeField] float offsetHorizontal = 1.25f;
    [SerializeField] float offsetVertical = 1.5f;
    [SerializeField] float minDistanceStop = .5f;    

    private void FixedUpdate()
    {
        if (Vector3.Distance(getTargetPosition(), transform.position) > minDistanceStop)
            transform.position = Vector3.Lerp(transform.position, getTargetPosition() + getRelativePosition(), speed * Time.deltaTime);
            
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
