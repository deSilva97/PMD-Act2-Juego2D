using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : Menu
{
    [SerializeField] GameObject content;

    [SerializeField] LevelUI[] levels;

    [SerializeField] int buildIndexLevelStart = 1;

    private void Start()
    {
        Close();

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].SetLevel(LevelManager.LoadLevel(i + 1));
        }
            
    }

    public override void Close()
    {        
        content.SetActive(false);
    }

    public override void Open()
    {
        content.SetActive(true);
    }
}
