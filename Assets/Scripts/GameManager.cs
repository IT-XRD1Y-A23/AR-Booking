using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SettingsData SettingsData;

    void Start()
    {
        LoadSettingsData();
    }

    private void onDisable()
    {
        SaveSettingsData();
    }

    private void SaveSettingsData()
    {
        PlayerPrefs.SetString("group", SettingsData.Group);
        PlayerPrefs.SetInt("groupIndex", SettingsData.GroupIndex);
    }

    private void LoadSettingsData()
    {
        SettingsData.Group = PlayerPrefs.GetString("group");
        SettingsData.GroupIndex = PlayerPrefs.GetInt("groupIndex");
    }
}
