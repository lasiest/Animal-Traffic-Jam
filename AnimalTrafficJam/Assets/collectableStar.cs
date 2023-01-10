using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableStar : MonoBehaviour
{
    public bool starCollected;

    private void Start() {
        starCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            starCollected = true;
            Debug.Log("Trigger player");
        }
    }
}
