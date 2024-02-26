using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource pointSource;

    private void OnEnable()
    {
        LevelManager.onPointAdded += PlayPointsAdded;
    }

    private void OnDisable()
    {
        LevelManager.onPointAdded -= PlayPointsAdded;
    }

    private void PlayPointsAdded(int current, int value)
    {
        if(value > 0)
        {
            pointSource.Play();
        }
    }

}
