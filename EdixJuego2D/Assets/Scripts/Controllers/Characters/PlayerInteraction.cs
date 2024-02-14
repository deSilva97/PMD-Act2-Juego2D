using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        /*
        IPickeable pickeable = collision.GetComponent<IPickeable>();
        if (pickeable != null)
        {
            Item id = pickeable.getItemID();     
            switch (id)
            {
                case Item.coin: PlayerManager.Instance.setCoins(PlayerManager.Instance.getCoins() + 1);
                    break;
                case Item.key: PlayerManager.Instance.setKey(true);
                    break;
                default: 
                    Debug.LogWarning("No hay un caso definido para esta interacción: " + collision.gameObject.name);
                    break;
            }
        }
            */
    }
}
