using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerManager.Instance.getKey())
            pick();
        
    }

    public void pick()
    {
        gameObject.SetActive(false);
        PlayerManager.Instance.setKey(true);
    }
}
