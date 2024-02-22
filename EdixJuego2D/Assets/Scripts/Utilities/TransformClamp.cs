using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TransformClamp : MonoBehaviour
{
    [SerializeField] Vector2 xLimits;
    [SerializeField] Vector2 yLimits;


    private void LateUpdate()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, xLimits.x, xLimits.y);
        position.y = Mathf.Clamp(position.y, yLimits.x, yLimits.y);        

        transform.position = position;
    }
}
