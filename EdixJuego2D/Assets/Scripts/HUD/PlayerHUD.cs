using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image currentLife;
    [SerializeField] TextMeshProUGUI numberLifes;
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] Image key;
    [SerializeField] Image[] chests;

    [Header("Params")]    
    [SerializeField][Range(0, 1)] float alphaChests = .2f;


    private void OnEnable()
    {
        PlayerController.onPlayerLifeChange += SetLifeBar;
        PlayerController.onCoinsAdd += SetPoints;
        PlayerController.onKeyPicked += () => key.gameObject.SetActive(true);
        PlayerController.onChestOpen += SetChestAlpha;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerLifeChange -= SetLifeBar;
        PlayerController.onCoinsAdd -= SetPoints;
        PlayerController.onKeyPicked -= () => key.gameObject.SetActive(true);
        PlayerController.onChestOpen -= SetChestAlpha;
    }

    private void Start()
    {
        key.gameObject.SetActive(false);

        foreach(Image i in chests)
            i.color = new Color(i.color.r, i.color.g, i.color.b, alphaChests);
    }

    private void SetLifeBar(int current, int max)
    {
        float dif = (float)current / max;

        Debug.Log(current + "/" + max + "=" + dif);
        currentLife.fillAmount = dif;
        
    }

    private void SetPoints(int value)
    {
        points.text = "x " + value.ToString();
    }

    private void SetChestAlpha(int number)
    {
        if (number > chests.Length)
            number = chests.Length;


        for(int i = 0; i < chests.Length; i++)
        {
            chests[i].color = new Color(chests[i].color.r, chests[i].color.g, chests[i].color.b, (i < number) ? 1: alphaChests);
        }
    }
}
