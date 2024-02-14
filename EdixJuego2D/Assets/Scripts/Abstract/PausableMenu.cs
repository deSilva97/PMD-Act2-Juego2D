using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PausableMenu : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] protected KeyCode inputKey;
    [SerializeField] protected Button inputButton;

    [Header("Content")]
    [SerializeField] protected GameObject content;    

    public bool isOpen { get; protected set; }

    protected void Start()
    {
        if(inputButton != null)
            inputButton.onClick.AddListener(HandleInputs);
    }

    protected void Update()
    {
        if (Input.GetKeyDown(inputKey))
            HandleInputs();
    }

    protected void HandleInputs()
    {
        if (isOpen)
            Close();
        else Open();

        isOpen = !isOpen;
    }

    public abstract void Open();
    public abstract void Close();
}
