using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    LevelManager.Level myLevel;

    [Header("Inputs")]
    [SerializeField] Button chooseLevelButton;
    [Header("References")]
    [SerializeField] TextMeshProUGUI numberText;
    [SerializeField] Image iconLock;
    [Space]
    [SerializeField] GameObject starContent;
    [SerializeField] GameObject[] starsContent;

    public LevelManager.Level MyLevel { get { return myLevel; } }

    private void Start()
    {
        chooseLevelButton.onClick.AddListener(SelectLevel);
    }

    public void SetLevel(LevelManager.Level level)
    {
        myLevel = level;

        iconLock.gameObject.SetActive(!level.complete);

        numberText.text = level.id.ToString();
        chooseLevelButton.gameObject.SetActive(myLevel.complete);
        
        starContent.SetActive(level.complete);

        for (int i = 0; i < starsContent.Length; i++)
        {
            if(i < level.stars) 
                starsContent[i].SetActive(true);
            else starsContent[i].SetActive(false);
        }
        
    }

    public void CanClickButton()
    {
        chooseLevelButton.gameObject.SetActive(true);
        iconLock.gameObject.SetActive(false);
    }

    private void SelectLevel()
    {
        Debug.Log("Cargando nivel: Level" + myLevel.id);
        LevelManager.currentLevel = myLevel.id;
        SceneController.Instance.LoadScene("Level " + myLevel.id);
    }

}
