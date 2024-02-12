using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item : byte {coin, key }
public interface IPickeable
{
    public Item getItemID();
}
