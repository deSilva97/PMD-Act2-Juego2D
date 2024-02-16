using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStarsUI : MonoBehaviour
{
    [SerializeField] Image[] stars;
    [SerializeField] float timeBetweenStars = 1f;

    int maxStarsVisible;
    int currentStars;
    float timer;


    private void OnEnable()
    {
        LevelManager.onStarsCompareEnds += UpdateStars;
    }

    private void OnDisable()
    {
        LevelManager.onStarsCompareEnds -= UpdateStars;

    }

    private void Start()
    {
        timer = timeBetweenStars;
        foreach (var img in stars)
            img.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (maxStarsVisible == currentStars)
            return;

        timer -= Time.deltaTime;

        if (timer > 0)
            return;

        timer = timeBetweenStars;
        stars[currentStars].gameObject.SetActive(true);
        currentStars++;

    }


    private void UpdateStars(int stars)
    {
        maxStarsVisible = stars;
    }

}
