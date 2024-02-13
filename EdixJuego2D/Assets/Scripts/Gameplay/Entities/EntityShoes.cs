using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityShoes : MonoBehaviour
{
    public bool isLanding { get; private set; }

    bool reload = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (reload)
            return;

        isLanding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLanding = false;
    }

    public void ForeceLandOff()
    {         
        isLanding = false;
        reload = true;
        Invoke("LandOn", .15f);
    }

    public void LandOn()
    {
        reload = false;
    }
}
