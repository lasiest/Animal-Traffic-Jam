using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelSelectionManager : MonoBehaviour
{   

    public TextMeshProUGUI Star;

    public int level1Star;
    public GameObject level1Star_1star;
    public GameObject level1Star_2star;
    public GameObject level1Star_3star;
    public int level2Star;
    public GameObject level2Star_1star;
    public GameObject level2Star_2star;
    public GameObject level2Star_3star;
    public int level3Star;
    public GameObject level3Star_1star;
    public GameObject level3Star_2star;
    public GameObject level3Star_3star;
    public int level4Star;
    public GameObject level4Star_1star;
    public GameObject level4Star_2star;
    public GameObject level4Star_3star;
    public int level5Star;
    public GameObject level5Star_1star;
    public GameObject level5Star_2star;
    public GameObject level5Star_3star;

    public int totalStar;
    public int starReduction;
    
    public int speedUpgraded = 0;
    public int invisibleUpgraded = 0;

    private void Start() {
        level1Star = PlayerPrefs.GetInt("level1Star");
        level2Star = PlayerPrefs.GetInt("level2Star");
        level3Star = PlayerPrefs.GetInt("level3Star");
        level4Star = PlayerPrefs.GetInt("level4Star");
        level5Star = PlayerPrefs.GetInt("level5Star");
        speedUpgraded = PlayerPrefs.GetInt("speedUpgraded");
        invisibleUpgraded = PlayerPrefs.GetInt("invisibleUpgraded");
        starReduction = PlayerPrefs.GetInt("StarReduction");
        AssignStar();
       
    }

    private void Update() {
        totalStar = level1Star + level2Star + level3Star + level4Star + level5Star - starReduction;
        Star.text = totalStar.ToString();

    }

    public void upgradeSpeedDur(){
        if(totalStar >= 5 && speedUpgraded != 1){
            starReduction = starReduction + 5;
            PlayerPrefs.SetInt("StarReduction", starReduction);
            PlayerPrefs.SetInt("speedDur", 7);
            PlayerPrefs.SetInt("speedUpgraded", 1);            
        }
    }

    public void upgradeInvisibleDur(){
        if(totalStar >= 5 && invisibleUpgraded != 1){
            starReduction  = starReduction + 5;
            PlayerPrefs.SetInt("StarReduction", starReduction);
            PlayerPrefs.SetInt("invisibleDur", 7);
            PlayerPrefs.SetInt("InvisibleUpgraded", 1);
        }
    }

    public void Level1(){
            SceneManager.LoadScene("Level 1");
    }
    public void Level2(){
        if(level1Star > 0){
            SceneManager.LoadScene("Level 2");
        }
    }
    public void Level3(){
        if(level2Star > 0){
            SceneManager.LoadScene("Level 3");
        }
    }
    public void Level4(){
        if(level3Star > 0){
            SceneManager.LoadScene("Level 4");
        }    
    }
    public void Level5(){
        if(level4Star > 0){
            SceneManager.LoadScene("Level 5");
        }
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

    public void Encyclopedia()
    {
        SceneManager.LoadScene("Encyclopedia");
    }

    public void EncyExplain()
    {
        SceneManager.LoadScene("EncyExplain");
    }

    public void EncyExplain2()
    {
        SceneManager.LoadScene("EncyExplain2");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void AssignStar(){
        level1Star_1star.SetActive(false);
        level1Star_2star.SetActive(false);
        level1Star_3star.SetActive(false);
        level2Star_1star.SetActive(false);
        level2Star_2star.SetActive(false);
        level2Star_3star.SetActive(false);
        level3Star_1star.SetActive(false);
        level3Star_2star.SetActive(false);
        level3Star_3star.SetActive(false);
        level4Star_1star.SetActive(false);
        level4Star_2star.SetActive(false);
        level4Star_3star.SetActive(false);
        level5Star_1star.SetActive(false);
        level5Star_2star.SetActive(false);
        level5Star_3star.SetActive(false);
        if(level1Star == 1){
            level1Star_1star.SetActive(true);
        }else if(level1Star == 2){
            level1Star_2star.SetActive(true);
        }else if(level1Star == 3){
            level1Star_3star.SetActive(true);
        }
        if(level2Star == 1){
            level2Star_1star.SetActive(true);
        }else if(level2Star == 2){
            level2Star_2star.SetActive(true);
        }else if(level2Star == 3){
            level2Star_3star.SetActive(true);
        }
        if(level3Star == 1){
            level3Star_1star.SetActive(true);
        }else if(level3Star == 2){
            level3Star_2star.SetActive(true);
        }else if(level3Star == 3){
            level3Star_3star.SetActive(true);
        }
        if(level4Star == 1){
            level4Star_1star.SetActive(true);
        }else if(level4Star == 2){
            level4Star_2star.SetActive(true);
        }else if(level4Star == 3){
            level4Star_3star.SetActive(true);
        }
        if(level5Star == 1){
            level5Star_1star.SetActive(true);
        }else if(level5Star == 2){
            level5Star_2star.SetActive(true);
        }else if(level5Star == 3){
            level5Star_3star.SetActive(true);
        }         
    }
}
