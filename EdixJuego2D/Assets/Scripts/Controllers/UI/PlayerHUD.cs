using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] Image currentLife;
    [SerializeField] Image[] hearths;
    [SerializeField] TextMeshProUGUI numberLifes;
    [SerializeField] TextMeshProUGUI points;    

    [SerializeField] Image[] chests;

    [Header("Stars")]    
    [SerializeField][Range(0, 1)] float alphaChests = .2f;
    [Header("Life")]    
    [SerializeField] Sprite[] hearthSprites;


    private void OnEnable()
    {
        PlayerController.onPlayerLifeChange += SetLifeSprite;
        PlayerManager.onExtraLifesChanges += UpdateTries;
        LevelManager.onPointAdded += SetPoints;
        PlayerManager.onChestOpened += SetChestAlpha;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerLifeChange -= SetLifeSprite;
        PlayerManager.onExtraLifesChanges -= UpdateTries;
        LevelManager.onPointAdded -= SetPoints;
        PlayerManager.onChestOpened -= SetChestAlpha;
    }

    private void Start()
    {        
        foreach(Image i in chests)
            i.color = new Color(i.color.r, i.color.g, i.color.b, alphaChests);
    }

    private void SetLifeSprite(int current, int max)
    {
        foreach (Image img in hearths)
            img.sprite = hearthSprites[0];

        int indexHearth = 0;

        for (int i = 1; i <= current; i++)
        {
            if(i % 2 == 0)
            {
                hearths[indexHearth].sprite = hearthSprites[1];
                indexHearth++;
            }
            else hearths[indexHearth].sprite = hearthSprites[2];
        }

    }

    private void SetPoints(int currentValue, int amount)
    {
        points.text = currentValue.ToString();
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
    private void UpdateTries(int value)
    {
        numberLifes.text = "x" + value;
    }

}
