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

    private void OnEnable()
    {
        GameManager.onGameWin += Show;
    }

    private void OnDisable()
    {
        GameManager.onGameWin -= Show;
    }

    private void Start()
    {
        continueButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Main));
        
        contentPanel.SetActive(false);
    }

    private void Show()
    {
        contentPanel.SetActive(true);
    }
}
