using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuHandler
{
    public static Menu savedToBackMenu;

    public static void changeMenu(Menu to, Menu from = null, bool returnable = false)
    {
        if (from != null)
        {
            if (returnable)
                savedToBackMenu = from;

            from.Close();
        }

        if (to != null)
            to.Open();
    }

    public static void returnMenu(Menu from = null, bool returnable = false)
    {
        Menu aux = savedToBackMenu;
        savedToBackMenu = null;
        changeMenu(aux, from, returnable);        
    }
}
