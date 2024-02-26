using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SplashUI : MonoBehaviour
{
    public static bool firstTime ;

    [Header("References")]
    [SerializeField] RawImage myImage;
    [SerializeField] VideoPlayer gif;
    [Header("Timer")]
    [SerializeField] float speedFadeOut = 1;
    

    IEnumerator Start()
    {
        gameObject.SetActive(!firstTime);

        firstTime = false;

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

        SceneManager.LoadScene("MainMenuScene");

        gameObject.SetActive(false);
    }

    private void PlayVideo()
    {
        gif.Play();
    }
}
