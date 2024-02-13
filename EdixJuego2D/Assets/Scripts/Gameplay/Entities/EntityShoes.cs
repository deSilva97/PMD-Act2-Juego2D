using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityShoes : MonoBehaviour
{
    public bool isLanding { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        isLanding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLanding = false;
    }

    public void ForeceLandOff() => isLanding = false;
}
