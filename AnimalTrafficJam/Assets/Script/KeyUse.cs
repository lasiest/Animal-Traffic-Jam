using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUse : MonoBehaviour
{

    Inventory inventory;
    BoxCollider2D _col;
    PickupItem PickupItem;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _col = gameObject.GetComponent<BoxCollider2D>();
        PickupItem = GameObject.FindGameObjectWithTag("Key").GetComponent<PickupItem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit detected");
        if (gameObject.tag=="Cage")
        {
            if (inventory.keycount > 0)
            {
                Debug.Log("hit cage");
                _col.enabled = false;
            }
        }
        
    }
}
