using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);

        IPickeable pickeable = collision.GetComponent<IPickeable>();
        if (pickeable != null)
        {
            Item id = pickeable.getItemID();     
            switch (id)
            {
                case Item.coin: controller.GiveCoin(1);
                    break;
                case Item.key: controller.GiveKey();
                    break;
                default: 
                    Debug.LogWarning("No hay un caso definido para esta interacción: " + collision.gameObject.name);
                    break;
            }
        }
            
    }
}
