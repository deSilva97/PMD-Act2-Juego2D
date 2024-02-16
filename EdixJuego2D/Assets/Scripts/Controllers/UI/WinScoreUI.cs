using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI yourScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        LevelManager.onScoreCompareEnds += UpdateScore;

    }

    private void OnDisable()
    {
        LevelManager.onScoreCompareEnds -= UpdateScore;
    }

    private void Start()
    {
        yourScoreText.text = "";
        highScoreText.text = "";
    }


    private void UpdateScore(int score, int highscore)
    {
        yourScoreText.text = score.ToString();

        if(highscore < score)
            highScoreText.text = "New Highscore!!!";
        else highScoreText.text = "Highscore: " + highscore.ToString();
    }
}
