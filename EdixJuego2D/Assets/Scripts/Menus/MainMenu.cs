using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Invoke(nameof(HandlePlay), 1f);
    }

    private void HandlePlay()
    {
        SceneManager.LoadScene(1);
    }
  
}
