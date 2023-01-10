using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishArea : MonoBehaviour
{
    public bool reachFinishedArea;
    private void Start() {
        reachFinishedArea = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            reachFinishedArea = true;
            Debug.Log("Trigger player");
        }
    }
}
