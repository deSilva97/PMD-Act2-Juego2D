using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        HandlePlay();
    }

    private void HandlePlay()
    {
        SceneManager.LoadScene(1);
    }
  
}