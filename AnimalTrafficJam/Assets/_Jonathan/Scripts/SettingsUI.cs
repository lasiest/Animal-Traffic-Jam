using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Scrollbar soundScrollbar;

    private void Start()
    {
        if (soundScrollbar != null)
        {
            soundScrollbar.value = PlayerPrefs.GetFloat("soundVolume");
            SoundManager.instance.GetAudioSource().volume = PlayerPrefs.GetFloat("soundVolume");
            soundScrollbar.onValueChanged.AddListener(OnValueChanged);
        }
    }

    private void OnValueChanged(float value)
    {
        SoundManager.instance.GetAudioSource().volume = value;
        PlayerPrefs.SetFloat("soundVolume", value);
    }

    private void OnDestroy()
    {
        if (soundScrollbar != null)
        {
            soundScrollbar.onValueChanged.RemoveListener(OnValueChanged);
        }
    }

    private void OnDisable()
    {
        if (soundScrollbar != null)
        {
            soundScrollbar.onValueChanged.RemoveListener(OnValueChanged);
        }
    }
}
