using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Animations
{
    public abstract class CodeAnimation : MonoBehaviour
    {
        public void Play() => StartCoroutine(nameof(RunAnimation));
        public void Stop() => StopCoroutine(nameof(RunAnimation));

        protected abstract IEnumerator RunAnimation();
    }

}
