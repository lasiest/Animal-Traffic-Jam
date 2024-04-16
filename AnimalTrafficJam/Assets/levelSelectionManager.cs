using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelSelectionManager : MonoBehaviour
{   

    public TextMeshProUGUI Star;
    public TextMeshProUGUI InvisibleUpgradeText;
    public TextMeshProUGUI speedUpgradeText;
    [SerializeField] private AudioClip Click;

    [Header("Level 1")]
    public int level1Star;
    public GameObject level1Star_1star;
    public GameObject level1Star_2star;
    public GameObject level1Star_3star;

    [Header("Level 2")]
    public int level2Star;
    public GameObject level2Star_1star;
    public GameObject level2Star_2star;
    public GameObject level2Star_3star;

    [Header("Level 3")]
    public int level3Star;
    public GameObject level3Star_1star;
    public GameObject level3Star_2star;
    public GameObject level3Star_3star;

    [Header("Level 4")]
    public int level4Star;
    public GameObject level4Star_1star;
    public GameObject level4Star_2star;
    public GameObject level4Star_3star;

    [Header("Level 5")]
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
        invisibleUpgraded = PlayerPrefs.GetInt("InvisibleUpgraded");
        starReduction = PlayerPrefs.GetInt("StarReduction");

        AssignStar();

        if(speedUpgraded == 0){
            PlayerPrefs.SetInt("speedDur", 5);
        }
        if(invisibleUpgraded == 0){
            PlayerPrefs.SetInt("invisibleDur", 5);
        }
    }

    private void Update() {
        totalStar = level1Star + level2Star + level3Star + level4Star + level5Star - starReduction;

        if (Star != null)
        {
            Star.text = totalStar.ToString();
        }

        if(PlayerPrefs.GetInt("speedUpgraded") == 1){
            speedUpgradeText.text = "Maxed Upgraded";
        }
        if(PlayerPrefs.GetInt("invisibleUpgraded") == 1){
            InvisibleUpgradeText.text = "Maxed Upgraded";
        }
    }

    public void upgradeSpeedDur(){
        if(totalStar >= 5 && speedUpgraded != 1){
            starReduction += 5;
            PlayerPrefs.SetInt("StarReduction", starReduction);
            PlayerPrefs.SetInt("speedDur", 7);
            PlayerPrefs.SetInt("speedUpgraded", 1);
            speedUpgradeText.text = "Maxed Upgraded";

            Debug.Log("Speed Upgraded!");
        }
    }

    public void upgradeInvisibleDur(){
        if(totalStar >= 5 && invisibleUpgraded != 1){
            starReduction += 5;
            PlayerPrefs.SetInt("StarReduction", starReduction);
            PlayerPrefs.SetInt("invisibleDur", 7);
            PlayerPrefs.SetInt("InvisibleUpgraded", 1);
            InvisibleUpgradeText.text = "Maxed Upgraded";
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
        //Delete Player Prefs
        // PlayerPrefs.DeleteAll();
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

    public void EncyExplain3()
    {
        SceneManager.LoadScene("EncyExplain3");
    }

    public void EncyExplain4()
    {
        SceneManager.LoadScene("EncyExplain4");
    }

    public void EncyExplain5()
    {
        SceneManager.LoadScene("EncyExplain5");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClickSound()
    {
        SoundManager.instance.PlaySound(Click);
    }
    private void AssignStar(){
        if (level1Star_1star != null)
        {
            level1Star_1star.SetActive(false);
        }

        if (level1Star_2star != null)
        {
            level1Star_2star.SetActive(false);
        }

        if (level1Star_3star != null)
        {
            level1Star_3star.SetActive(false);
        }

        if (level2Star_1star != null)
        {
            level2Star_1star.SetActive(false);
        }

        if (level2Star_2star != null)
        {
            level2Star_2star.SetActive(false);
        }

        if (level2Star_3star != null)
        {
            level2Star_3star.SetActive(false);
        }

        if (level3Star_1star != null)
        {
            level3Star_1star.SetActive(false);
        }

        if (level3Star_2star != null)
        {
            level3Star_2star.SetActive(false);
        }

        if (level3Star_3star != null)
        {
            level3Star_3star.SetActive(false);
        }

        if (level4Star_1star != null)
        {
            level4Star_1star.SetActive(false);
        }

        if (level4Star_2star != null)
        {
            level4Star_2star.SetActive(false);
        }

        if (level4Star_3star != null)
        {
            level4Star_3star.SetActive(false);
        }

        if (level5Star_1star != null)
        {
            level5Star_1star.SetActive(false);
        }

        if (level5Star_2star != null)
        {
            level5Star_2star.SetActive(false);
        }

        if (level5Star_3star != null)
        {
            level5Star_3star.SetActive(false);
        }

        if(level1Star == 1 && level1Star_1star != null)
        {
            level1Star_1star.SetActive(true);
        }else if(level1Star == 2 && level1Star_2star != null)
        {
            level1Star_2star.SetActive(true);
        }else if(level1Star == 3 && level1Star_3star != null)
        {
            level1Star_3star.SetActive(true);
        }

        if(level2Star == 1 && level2Star_1star != null)
        {
            level2Star_1star.SetActive(true);
        }else if(level2Star == 2 && level2Star_2star != null)
        {
            level2Star_2star.SetActive(true);
        }else if(level2Star == 3 && level2Star_3star != null)
        {
            level2Star_3star.SetActive(true);
        }
        if(level3Star == 1 && level3Star_1star != null)
        {
            level3Star_1star.SetActive(true);
        }else if(level3Star == 2 && level3Star_2star != null)
        {
            level3Star_2star.SetActive(true);
        }else if(level3Star == 3 && level3Star_3star != null)
        {
            level3Star_3star.SetActive(true);
        }
        if(level4Star == 1 && level4Star_1star != null)
        {
            level4Star_1star.SetActive(true);
        }else if(level4Star == 2 && level4Star_2star != null)
        {
            level4Star_2star.SetActive(true);
        }else if(level4Star == 3 && level4Star_3star != null)
        {
            level4Star_3star.SetActive(true);
        }
        if(level5Star == 1 && level5Star_1star != null)
        {
            level5Star_1star.SetActive(true);
        }else if(level5Star == 2 && level5Star_2star != null)
        {
            level5Star_2star.SetActive(true);
        }else if(level5Star == 3 && level5Star_3star != null)
        {
            level5Star_3star.SetActive(true);
        }         
    }
}
