using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, IPickeable
{
    [SerializeField] int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pick();
    }

    public void pick()
    {
        gameObject.SetActive(false);
        PlayerManager.Instance.setCoins(PlayerManager.Instance.getCoins() + value);
    }
}
