using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    public abstract void Open();
    public abstract void Close();    
}

public abstract class PausableMenu : Menu
{
 

    public override abstract void Open();
    public override abstract void Close();
}
