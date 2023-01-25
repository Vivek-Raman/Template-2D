using System.Collections.Generic;
using UnityEngine;
using wannaB.UI;

namespace wannaB.Settings
{
public class SettingsManager : MonoBehaviour
{
    [SerializeField] private List<SettingItem> settings;
    [SerializeField] private string settingsPrefix;

    private void Awake()
    {
        LoadSettings(false);
    }

    public void SaveSettings()
    {
        foreach (SettingItem item in settings)
        {
            string key = item.SettingData.Item1;
            string value = item.SettingData.Item2;
            PlayerPrefs.SetString(GetPrefsKey(key), value);
            PlayerPrefs.Save();
        }
    }

    public void LoadSettings(bool loadIntoUI)
    {
        foreach (SettingItem item in settings)
        {
            string key = item.SettingData.Item1;
            string newValue = PlayerPrefs.GetString(GetPrefsKey(key));
            item.LoadDefaultValue(newValue, loadIntoUI);
        }
    }

    private string GetPrefsKey(string key) => settingsPrefix + "." + key;
}
}
