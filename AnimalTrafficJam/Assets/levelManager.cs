using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public GameObject levelFinishedScene;
    public GameObject one_Star;
    public GameObject two_Star;
    public GameObject three_Star;
    public GameObject finishArea;
    public GameObject player;
    public GameObject collectableStar;
    public int maxAnimal;
    public int star;
    public bool firstStar;
    public bool secondStar;
    public bool thirdStar;
    public int currentLevel;
    public GameObject one_Star_InGame;
    public GameObject two_Star_InGame;
    public GameObject three_Star_InGame;

    void Start()
    {   
        star = 0;
        firstStar = false;
        levelFinishedScene.SetActive(false);
        one_Star_InGame.SetActive(false);
        two_Star_InGame.SetActive(false);
        three_Star_InGame.SetActive(false);
    }

    void Update()
    {
        if(finishArea.GetComponent<finishArea>().reachFinishedArea == true){
            levelFinishedScene.SetActive(true);
            if(star == 1){
                one_Star.SetActive(true);
            }else if(star == 2){
                two_Star.SetActive(true);
            }else if(star == 3){
                three_Star.SetActive(true);
            }
        }
        if(player.GetComponent<Inventory>().isFull[0] && firstStar == false){
            star += 1;
            firstStar = true;
        }
        if(player.GetComponent<Inventory>().isFull[maxAnimal] && secondStar == false){
            star += 1;
            secondStar = true;

        }
        if(collectableStar.GetComponent<collectableStar>().starCollected && thirdStar == false){
            star += 1;
            thirdStar = true;
            collectableStar.SetActive(false);

        }
        
        if(star == 1){
            one_Star_InGame.SetActive(true);
        }else if(star == 2){
            two_Star_InGame.SetActive(true);            
        }else if(star == 3){
            three_Star_InGame.SetActive(true);            
        }

        if(currentLevel == 1 && star > PlayerPrefs.GetInt("level1Star")){
            PlayerPrefs.SetInt("level1Star", star);
            // Debug.Log("insertStar");
        }else if(currentLevel == 2 && star > PlayerPrefs.GetInt("level2Star")){
            PlayerPrefs.SetInt("level2Star", star);
        }else if(currentLevel == 3 && star > PlayerPrefs.GetInt("level3Star")){
            PlayerPrefs.SetInt("level3Star", star);
        }else if(currentLevel == 4 && star > PlayerPrefs.GetInt("level4Star")){
            PlayerPrefs.SetInt("level4Star", star);
        }else if(currentLevel == 5 && star > PlayerPrefs.GetInt("level5Star")){
            PlayerPrefs.SetInt("level5Star", star);
        }
    }

}
