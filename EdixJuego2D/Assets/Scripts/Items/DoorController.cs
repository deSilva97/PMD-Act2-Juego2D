using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject uiContent;

    [SerializeField] bool oneUse = true;
    [SerializeField] bool isUsed;

    private void Start()
    {
        uiContent.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (oneUse && !isUsed && PlayerManager.Instance.getKey())
        {
            isUsed = true;
            LevelManager.Instance.Win();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isUsed)
        {
            uiContent.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiContent.SetActive(false);
    }



}
