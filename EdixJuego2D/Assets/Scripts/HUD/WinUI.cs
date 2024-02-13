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
        WinManager.onGameWin += Show;
    }

    private void OnDisable()
    {
        WinManager.onGameWin -= Show;
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
