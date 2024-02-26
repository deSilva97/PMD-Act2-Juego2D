using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] BreakablePlatform[] allPlaforms;

    private void Start()
    {
        //foreach (BreakablePlatform p in allPlaforms)
        //    p.onBreak += BreakAll;
    }


    private void BreakAll(float timeBreak, float timeRecover)
    {
        //for (int i = 0; i < allPlaforms.Length; i++)
        //    allPlaforms[i].Break(timeBreak, timeRecover);
    }
}
