using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    [SerializeField] GameObject contentLife;
    [SerializeField] GameObject contentNotify;

    [SerializeField] Image lifebar_back; 
    [SerializeField] Image lifebar_front;
    [SerializeField] TextMeshProUGUI notify_text;

    private void Start()
    {
        contentLife.SetActive(false);
    }

    public void SetLifeBar(int current, int max)
    {
        if(!contentLife.activeSelf)
            contentLife.SetActive(true);

        float dif = (float)current / max;

        Debug.Log(current + "/" + max + "=" + dif);
        lifebar_front.fillAmount = dif;
    }
    public void SetNotify(string chr = "")
    {
        contentNotify.SetActive(true);
        notify_text.text = chr;
     
    }

}
