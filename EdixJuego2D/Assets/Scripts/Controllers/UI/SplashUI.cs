using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SplashUI : MonoBehaviour
{
    public static bool firstTime ;

    [Header("References")]
    [SerializeField] RawImage myImage;
    [SerializeField] VideoPlayer gif;
    [Header("Timer")]
    [SerializeField] float timePlaying = 3;
    [SerializeField] float speedFadeOut = 1;
    

    IEnumerator Start()
    {
        gameObject.SetActive(!firstTime);

        if (!firstTime)
        {
            PlayVideo();
            firstTime = true;
            yield return new WaitForSeconds(3);
        }

        while(myImage.color.a > 0)
        {
            Color color = myImage.color;
            color.a -= Time.deltaTime * speedFadeOut;
            myImage.color = color;
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
    }

    private void PlayVideo()
    {
        gif.Play();
    }
}
