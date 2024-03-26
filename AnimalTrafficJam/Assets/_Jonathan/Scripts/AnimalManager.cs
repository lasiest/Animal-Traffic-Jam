using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance { get; private set; }

    private List<bool> animalLearnt;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            animalLearnt = new List<bool>();
            
            for (int i = 0; i < 5; i++)
            {
                animalLearnt.Add(false);
            }
        }
    }

    public void SetAnimalLearnt(int index)
    {
        if (index >= 0 && index < animalLearnt.Count)
        {
            animalLearnt[index] = true;

            switch (index)
            {
                case 0:
                    PlayerPrefs.SetInt("animal_1", 1);
                    break;
                case 1:
                    PlayerPrefs.SetInt("animal_2", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("animal_3", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("animal_4", 1);
                    break;
                case 4:
                    PlayerPrefs.SetInt("animal_5", 1);
                    break;
            }
        }
    }
}
