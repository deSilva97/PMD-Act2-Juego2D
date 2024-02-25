using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public class BreezeAnimation : CodeAnimation
    {
        [SerializeField] Vector3 finalScale;
        [SerializeField] float speed;        

        protected override IEnumerator RunAnimation()
        {
            Vector3 originScale = transform.localScale;
            Vector3 endScale = finalScale;

            while (true)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, endScale, speed * Time.deltaTime);

                if(Vector3.Distance(transform.localScale, endScale) < .1f)
                {
                    if (endScale == finalScale) endScale = originScale;
                    else endScale = finalScale;
                }

                yield return new WaitForEndOfFrame();
            }
        }

    }

}
