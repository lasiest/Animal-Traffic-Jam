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
    public float star;
    public bool firstStar;
    public bool secondStar;
    public bool thirdStar;

    void Start()
    {   
        star = 0;
        firstStar = false;
        levelFinishedScene.SetActive(false);
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
    }

}
