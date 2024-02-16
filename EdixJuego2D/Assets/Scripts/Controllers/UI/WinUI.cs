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
        EndGameManager.onGameWin += Show;
    }

    private void OnDisable()
    {
        EndGameManager.onGameWin -= Show;
    }

    private void Start()
    {
        continueButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Main));
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));

        contentPanel.SetActive(false);
    }

    private void Show()
    {
        contentPanel.SetActive(true);
    }
}
