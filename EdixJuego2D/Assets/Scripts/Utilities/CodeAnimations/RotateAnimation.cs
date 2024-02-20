using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace Utils.Animations
{
    public class RotateAnimation : CodeAnimation
    {

        [SerializeField] Vector3 rotateDirection;
        [SerializeField] float speed = 10;

        Vector3 rotateDirectionNormalized { get => rotateDirection.normalized; }

        protected override IEnumerator RunAnimation()
        {
            while (true)
            {
                transform.Rotate(rotateDirectionNormalized * speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}