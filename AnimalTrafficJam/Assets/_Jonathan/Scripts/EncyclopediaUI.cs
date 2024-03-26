using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaUI : MonoBehaviour
{
    [Serializable]
    public class AnimalInformation
    {
        public Button animalButton;
        public Image animalImage;
        public TextMeshProUGUI animalText;
        public Image lockImage;
        public string animalName;
        public bool isLearnt;
    }

    [Serializable]
    public class Encyclopedia
    {
        public GameObject pageGameObject;
        public List<AnimalInformation> animalInformationList;
    }

    [Header("Animal Informations")]
    public List<Encyclopedia> encyclopediaList;

    [Header("Buttons & UIs")]
    public Button nextButton;
    public Button previousButton;

    private int currentPage = 1;

    private void Awake()
    {
        nextButton.onClick.AddListener(() =>
        {
            currentPage++;
            for (int i = 0; i < encyclopediaList.Count; i++)
            {
                encyclopediaList[i].pageGameObject.SetActive(i == currentPage - 1);
            }
        });

        previousButton.onClick.AddListener(() =>
        {
            currentPage--;
            for (int i = 0; i < encyclopediaList.Count; i++)
            {
                encyclopediaList[i].pageGameObject.SetActive(i == currentPage - 1);
            }
        });
    }

    private void Start()
    {
        nextButton.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(false);

        CheckAnimalLearnt();
        SetAnimalUI();

        currentPage = 1;
    }

    private void Update()
    {
        if (currentPage == 1)
        {
            previousButton.gameObject.SetActive(false);
        }
        if (currentPage > 1 && currentPage < encyclopediaList.Count)
        {
            previousButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
        if (currentPage == encyclopediaList.Count)
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    private void CheckAnimalLearnt()
    {
        // page 1
        if (PlayerPrefs.GetInt("animal_1") == 1)
        {
            encyclopediaList[0].animalInformationList[0].isLearnt = true;
        }
        else
        {
            encyclopediaList[0].animalInformationList[0].isLearnt = false;
        }

        if (PlayerPrefs.GetInt("animal_2") == 1)
        {
            encyclopediaList[0].animalInformationList[1].isLearnt = true;
        }
        else
        {
            encyclopediaList[0].animalInformationList[1].isLearnt = false;
        }

        // page 2
        if (PlayerPrefs.GetInt("animal_3") == 1)
        {
            encyclopediaList[1].animalInformationList[0].isLearnt = true;
        }
        else
        {
            encyclopediaList[1].animalInformationList[0].isLearnt = false;
        }

        if (PlayerPrefs.GetInt("animal_4") == 1)
        {
            encyclopediaList[1].animalInformationList[1].isLearnt = true;
        }
        else
        {
            encyclopediaList[1].animalInformationList[1].isLearnt = false;
        }

        // page 3
        if (PlayerPrefs.GetInt("animal_5") == 1)
        {
            encyclopediaList[2].animalInformationList[0].isLearnt = true;
        }
        else
        {
            encyclopediaList[2].animalInformationList[0].isLearnt = false;
        }
    }

    private void SetAnimalUI()
    {
        for (int i = 0; i < encyclopediaList.Count; i++)
        {
            for (int j = 0; j < encyclopediaList[i].animalInformationList.Count; j++)
            {
                encyclopediaList[i].animalInformationList[j].lockImage.gameObject.SetActive(!encyclopediaList[i].animalInformationList[j].isLearnt);

                encyclopediaList[i].animalInformationList[j].animalImage.gameObject.SetActive(encyclopediaList[i].animalInformationList[j].isLearnt);

                encyclopediaList[i].animalInformationList[j].animalButton.interactable = encyclopediaList[i].animalInformationList[j].isLearnt;

                if (encyclopediaList[i].animalInformationList[j].isLearnt)
                {
                    encyclopediaList[i].animalInformationList[j].animalText.text = encyclopediaList[i].animalInformationList[j].animalName;
                }
                else
                {
                    encyclopediaList[i].animalInformationList[j].animalText.text = "Unknown Animal";
                }
            }
        }
    }
}
