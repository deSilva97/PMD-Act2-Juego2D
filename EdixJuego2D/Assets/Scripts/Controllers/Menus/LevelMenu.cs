using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : Menu
{
    [SerializeField] GameObject content;
    [SerializeField] LevelUI[] levels;

    private void Start()
    {

        //LevelManager.SaveLevel(new LevelManager.Level(2, 100, 0, true));
        //LevelManager.SaveLevel(new LevelManager.Level(3, 20, 2, true));

        Close();

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].SetLevel(LevelManager.LoadLevel(i + 1));
        }
         
        foreach(var level in levels)
        {
            if (!level.MyLevel.complete)
            {
                Debug.Log("Level" + level.MyLevel.id);
                level.CanClickButton();
                return;
            }
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
