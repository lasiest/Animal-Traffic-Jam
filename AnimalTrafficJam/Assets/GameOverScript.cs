using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject player;
    playerController _playerController;

    void Start() { 
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerController = player.GetComponent<playerController>();
        }

        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        
    }

}
