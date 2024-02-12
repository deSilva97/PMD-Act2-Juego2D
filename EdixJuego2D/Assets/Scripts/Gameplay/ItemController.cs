using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour, IPickeable
{
    [SerializeField] Item item;

    public Item getItemID()
    {
        gameObject.SetActive(false);
        return Item.coin;
    }
}
