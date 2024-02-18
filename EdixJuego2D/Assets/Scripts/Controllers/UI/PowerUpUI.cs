using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField] GameObject content;
    [Space]
    [SerializeField] Image powerBar;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI timerText;

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        PowerUpManager.onPowerUpIn += Show;
        PowerUpManager.onPowerUpOut += Hide;
        PowerUpManager.onCurrentTimeChanges += UpdateBar;
        PowerUpManager.onCurrentTimeChanges += UpdateTimer;

    }

    private void OnDisable()
    {
        PowerUpManager.onPowerUpIn -= Show;
        PowerUpManager.onPowerUpOut -= Hide;
        PowerUpManager.onCurrentTimeChanges -= UpdateBar;
        PowerUpManager.onCurrentTimeChanges -= UpdateTimer;
    }

    private void Show(string name)
    {
        content.SetActive(true);
        nameText.text = name + ": ";
    }

    private void Hide()
    {
        content.SetActive(false);
    }

    private void UpdateBar(float current, float max)
    {
        float v = (float)current / max;
        powerBar.fillAmount = v;

    }

    private void UpdateTimer(float current, float max)
    {
        int totalSeconds = (int)current;
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        string tMin = minutes < 10 ? "0" : "";
        tMin += minutes;

        string tSecs = seconds < 10 ? "0" : "";
        tSecs += seconds;

        timerText.text = tMin + ":" + tSecs;
    }
}
