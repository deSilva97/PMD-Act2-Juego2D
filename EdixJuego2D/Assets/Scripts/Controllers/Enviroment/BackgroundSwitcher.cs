using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    [SerializeField] Camera targetCamera;
    [Space]
    [SerializeField] int index;
    [SerializeField] Background[] myBackgrounds;

    private void Start()
    {
        if(targetCamera == null)
            targetCamera = Camera.main;

        for (int i = 0; i < myBackgrounds.Length; i++)
            myBackgrounds[i].bgContent.SetActive(false);

        SwitchBackground(index);
    }

    public void SwitchBackground(int index = 0)
    {
        myBackgrounds[this.index].bgContent.SetActive(false);

        this.index = index;

        targetCamera.backgroundColor = myBackgrounds[index].color;
        myBackgrounds[index].bgContent.SetActive(true);

    }

    [System.Serializable]
    public class Background
    {
        public Color color = Color.white;
        public GameObject bgContent;
    }

}
