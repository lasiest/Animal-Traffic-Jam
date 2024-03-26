using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPickUp : MonoBehaviour
{
    [SerializeField] private int animalIndex;
    private PickupItem pickUpItem;

    private void Start()
    {
        pickUpItem = gameObject.GetComponent<PickupItem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (pickUpItem.IsPickedUp)
            {
                AnimalManager.Instance.SetAnimalLearnt(animalIndex);
            }
        }
    }
}
