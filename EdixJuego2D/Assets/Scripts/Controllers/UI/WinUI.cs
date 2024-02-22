using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinUI : MonoBehaviour
{
    [SerializeField] GameObject contentPanel;
    [Space]
    [SerializeField] Button continueButton;
    [SerializeField] Button restartButton;


    private void OnEnable()
    {
        LevelManager.onGameWin += Show;
    }

    private void OnDisable()
    {
        LevelManager.onGameWin -= Show;
    }

    private void Start()
    {

        continueButton.onClick.AddListener(() => SceneController.Instance.LoadScene("MainMenuScene"));
        restartButton.onClick.AddListener(() => SceneController.Instance.LoadActiveScene());

        contentPanel.SetActive(false);
    }

    private void Show()
    {
        contentPanel.SetActive(true);
    }
}
