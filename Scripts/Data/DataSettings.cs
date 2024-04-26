using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public enum Language
{
    Russian,
    English
}

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Settings")]
public class DataSettings : ScriptableObject
{
    public float LookSensetivity;
    public ReactiveProperty<int> FpsMax = new ReactiveProperty<int>();
    public int MaxFpsMax;
    public float MaxLookSensetivity;
    public float MinLookSensetivity;
    public bool VSync = false;
    public ReactiveProperty<Language> SelectedLanguage = new ReactiveProperty<Language>();

    public Action DataChanged;

    public void DataUpdated()
    {
        Save();
        Debug.Log("DataUpdatet");
    }

    public void Save()
    {
        PlayerPrefs.SetString(nameof(SelectedLanguage), SelectedLanguage.Value.ToString());
        PlayerPrefs.SetFloat(nameof(LookSensetivity), LookSensetivity);
        PlayerPrefs.SetFloat(nameof(MaxLookSensetivity), MaxLookSensetivity);
        PlayerPrefs.SetFloat(nameof(MinLookSensetivity), MinLookSensetivity);
        PlayerPrefs.SetInt(nameof(FpsMax), FpsMax.Value);
        PlayerPrefs.SetInt(nameof(VSync), Convert.ToInt16(VSync));
        DataChanged?.Invoke();
    }

    public void Load()
    {
        if (PlayerPrefs.GetString(nameof(SelectedLanguage), "Russian") == "Russian")
        {
            SelectedLanguage.Value = Language.Russian;
        }
        else
        {
            SelectedLanguage.Value = Language.English;
        }

        LookSensetivity = PlayerPrefs.GetFloat(nameof(LookSensetivity), 0.1f);
        MaxLookSensetivity = PlayerPrefs.GetFloat(nameof(MaxLookSensetivity), 1f);
        MinLookSensetivity = PlayerPrefs.GetFloat(nameof(MinLookSensetivity), 0.1f);
        FpsMax.Value = PlayerPrefs.GetInt(nameof(FpsMax), 60);
        VSync = Convert.ToBoolean(PlayerPrefs.GetInt(nameof(VSync), 0));
        DataChanged?.Invoke();
    }
}