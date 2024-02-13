using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField] GameObject contentPanel;
    [Space]
    [SerializeField] Button restartButton;
    [SerializeField] Button backButton;

    private void OnEnable()
    {
        WinManager.onGameLose += Show;
    }

    private void OnDisable()
    {
        WinManager.onGameLose -= Show;
    }

    private void Start()
    {
        restartButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Gameplay));
        backButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Main));

        contentPanel.SetActive(false);
    }

    private void Show()
    {
        contentPanel.SetActive(true);
    }
}
