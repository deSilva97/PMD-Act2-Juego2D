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
    private void Start()
    {
        chooseLevelButton.onClick.AddListener(SelectLevel);
    }

    public void SetLevel(LevelManager.Level level)
    {
        myLevel = level;

        iconLock.gameObject.SetActive(level.complete);
        numberText.text = level.id.ToString();

        starContent.SetActive(level.complete);

        for(int i = 0; i < starsContent.Length; i++)
        {
            if(i < level.stars) 
                starsContent[i].SetActive(true);
            else starsContent[i].SetActive(false);
        }
        
    }

    private void SelectLevel()
    {
        Debug.Log(myLevel.id);
        Debug.Log("Se va a cargar la escena " + SceneManager.GetSceneByBuildIndex(myLevel.id));
        SceneController.Instance.LoadScene("SampleScene");
    }
}
