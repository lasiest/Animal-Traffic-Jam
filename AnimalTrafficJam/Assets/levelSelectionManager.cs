using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelSelectionManager : MonoBehaviour
{   

    public TextMeshProUGUI Star;

    public int level1Star;
    public int level2Star;
    public int level3Star;
    public int level4Star;
    public int level5Star;

    public int totalStar;
    
    private void Start() {
        level1Star = PlayerPrefs.GetInt("level1Star");
        level2Star = PlayerPrefs.GetInt("level2Star");
        level3Star = PlayerPrefs.GetInt("level3Star");
        level4Star = PlayerPrefs.GetInt("level4Star");
        level5Star = PlayerPrefs.GetInt("level5Star");
    }

    private void Update() {
        totalStar = level1Star + level2Star + level3Star + level4Star + level5Star;
        Star.text = totalStar.ToString();
    }

    public void Level1(){
        SceneManager.LoadScene("Level 1");
    }
    public void Level2(){
        SceneManager.LoadScene("Level 2");
    }
    public void Level3(){
        SceneManager.LoadScene("Level 3");
    }
    public void Level4(){
        SceneManager.LoadScene("Level 4");
    }
    public void Level5(){
        SceneManager.LoadScene("Level 5");
    }

    public void LevelSelection(){
        SceneManager.LoadScene("Level Selection");
    }

    public void Shop(){
        SceneManager.LoadScene("Shop");
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main menu");
    }
}
