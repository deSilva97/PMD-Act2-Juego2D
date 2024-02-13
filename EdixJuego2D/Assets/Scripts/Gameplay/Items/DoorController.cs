using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] bool open = false;

    [SerializeField] GameObject uiContent;

    private void Start()
    {
        uiContent.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!open)
        {
            if (PlayerManager.Instance.getKey())
            {
                open = true;
                OnTriggerStay2D(collision);
            }
            else
            {
                uiContent.SetActive(true);
            }

        }
        else
        {
            WinManager.Instance.Win();
            enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        uiContent.SetActive(false);
    }



}
