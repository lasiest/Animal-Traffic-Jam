using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    [SerializeField] private AudioClip Collect;
    private bool isPickedUp;

    public bool IsPickedUp
    {
        get
        {
            return isPickedUp;
        }
    }

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        isPickedUp = false;
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player")){
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false){
                    inventory.isFull[i] = true;
                    if (gameObject.tag == "Key")
                    {
                        inventory.keycount++;
                    }
                    SoundManager.instance.PlaySound(Collect);
                    Instantiate(itemButton, inventory.slots[i].transform,false);
                    isPickedUp = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
