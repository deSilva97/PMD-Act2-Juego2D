using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    [SerializeField] Vector3 distance;
    [SerializeField] float speed = 1;

    private void OnEnable()
    {
        LevelManager.onGameLose += StartMove;
        LevelManager.onGameWin += StartMove;
    }
    private void OnDisable()
    {
        LevelManager.onGameLose -= StartMove;
        LevelManager.onGameWin -= StartMove;
    }

    private void StartMove() => StartCoroutine(IMoveDirection(distance, speed));

    IEnumerator IMoveDirection(Vector3 offset, float speed)
    {
        Vector3 finalPosition = transform.position + offset;
        Vector3 direction = (finalPosition - transform.position).normalized;

        Debug.Log(finalPosition + "#" + transform.position);

        while(Vector3.Distance(finalPosition, transform.position) > .5f){
            transform.position += direction * speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }
}
