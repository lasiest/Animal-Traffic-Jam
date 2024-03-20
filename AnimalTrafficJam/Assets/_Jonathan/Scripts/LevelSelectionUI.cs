using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;

    private void Start()
    {
        SetLevelButtonUI(level1Button, true);

        if (PlayerPrefs.GetInt("level1Star") > 0)
        {
            SetLevelButtonUI(level2Button, true);
        }
        else
        {
            SetLevelButtonUI(level2Button, false);
        }

        if (PlayerPrefs.GetInt("level2Star") > 0)
        {
            SetLevelButtonUI(level3Button, true);
        }
        else
        {
            SetLevelButtonUI(level3Button, false);
        }

        if (PlayerPrefs.GetInt("level3Star") > 0)
        {
            SetLevelButtonUI(level4Button, true);
        }
        else
        {
            SetLevelButtonUI(level4Button, false);
        }

        if (PlayerPrefs.GetInt("level4Star") > 0)
        {
            SetLevelButtonUI(level5Button, true);
        }
        else
        {
            SetLevelButtonUI(level5Button, false);
        }
    }

    private void SetLevelButtonUI(Button button, bool active)
    {
        button.gameObject.SetActive(active);
    }
}
