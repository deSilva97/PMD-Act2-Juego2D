using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeEndGame : MonoBehaviour
{
    [SerializeField] float speed;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.enabled = false;
    }

    private void OnEnable()
    {
        EndGameManager.onGameWin += FadeIn;
        EndGameManager.onGameLose += FadeIn;
    }

    private void OnDisable()
    {
        EndGameManager.onGameWin -= FadeIn;
        EndGameManager.onGameLose -= FadeIn;
    }

    public void FadeIn() => StartCoroutine(IFadeIn(0));
    IEnumerator IFadeIn(float alpha = 0)
    {
        image.enabled = true;
        while (alpha < 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            alpha += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }

}