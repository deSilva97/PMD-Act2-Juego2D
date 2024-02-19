using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] Transform targetCamera;

    [SerializeField] [Range(0f, 1f)] float xDeltaMultiplier = 1;
    [SerializeField] [Range(0f, 1f)] float yDeltaMultiplier = 1;

    Vector3 previousCameraPosition;

    private void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        float xDelta = (targetCamera.position.x - previousCameraPosition.x) * xDeltaMultiplier;
        float yDelta = (targetCamera.position.y - previousCameraPosition.y) * yDeltaMultiplier;

        transform.Translate(new Vector2(xDelta, yDelta));

        previousCameraPosition = targetCamera.position;
    }
}
