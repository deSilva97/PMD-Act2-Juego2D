using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField] GameObject contentPanel;
    [Space]
    [SerializeField] Button restartButton;
    [SerializeField] Button backButton;

    private void OnEnable()
    {
        EndGameManager.onGameLose += Show;
    }

    private void OnDisable()
    {
        EndGameManager.onGameLose -= Show;
    }

    private void Start()
    {
        restartButton.onClick.AddListener(() => SceneController.Instance.LoadActiveScene());
        backButton.onClick.AddListener(() => SceneController.Instance.LoadScene("MainMenuScene"));

        contentPanel.SetActive(false);
    }

    private void Show()
    {
        contentPanel.SetActive(true);
    }
}
