using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Button upgradeInvisibleButton;
    [SerializeField] private TextMeshProUGUI upgradeInvisibleText;
    [SerializeField] private Button upgradeSpeedButton;
    [SerializeField] private TextMeshProUGUI upgradeSpeedText;

    private void Update()
    {
        if (PlayerPrefs.GetInt("InvisibleUpgraded") == 1)
        {
            upgradeInvisibleButton.interactable = false;
            upgradeInvisibleText.text = "Maxed Upgraded";
        }
        else
        {
            upgradeInvisibleButton.interactable = true;
            upgradeInvisibleText.text = "Upgrade (Cost: 5 Stars)";
        }

        if (PlayerPrefs.GetInt("speedUpgraded") == 1)
        {
            upgradeSpeedButton.interactable = true;
            upgradeSpeedText.text = "Maxed Upgraded";
        }
        else
        {
            upgradeSpeedButton.interactable = true;
            upgradeSpeedText.text = "Upgrade (Cost: 5 Stars)";
        }
    }
}
