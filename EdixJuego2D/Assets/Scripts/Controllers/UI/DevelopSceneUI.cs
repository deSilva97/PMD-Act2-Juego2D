using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopSceneUI : MonoBehaviour
{
    
    public void LoadScene()
    {
        
        SceneController.Instance.LoadScene("Level " + 0);
    }
}
