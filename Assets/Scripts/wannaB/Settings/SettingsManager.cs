using System.Collections.Generic;
using UnityEngine;
using wannaB.UI;

namespace wannaB.Settings
{
public class SettingsManager : MonoBehaviour
{
    [SerializeField] private List<SettingItem> settings;
    [SerializeField] private string settingsPrefix;

    public void SaveSettings()
    {
        foreach (SettingItem item in settings)
        {
            PlayerPrefs.SetString(GetPrefsKey(item.SettingKey), item.SettingValue);
        }

        PlayerPrefs.Save();
    }

    public void LoadSettings(bool loadIntoUI)
    {
        foreach (SettingItem item in settings)
        {
            string newValue = PlayerPrefs.GetString(GetPrefsKey(item.SettingKey), item.SettingDefaultValue);
            item.LoadSettingValue(newValue, loadIntoUI);
        }
    }

    public void TrySaveFirstLaunchSettings()
    {
        const string firstLaunchKey = "Returning Player";
        if (bool.Parse(PlayerPrefs.GetString(GetPrefsKey(firstLaunchKey), "false"))) return;
        foreach (SettingItem item in settings)
        {
            PlayerPrefs.SetString(GetPrefsKey(item.SettingKey), item.SettingDefaultValue);
        }

        PlayerPrefs.SetString(GetPrefsKey(firstLaunchKey), "true");
        PlayerPrefs.Save();
    }

    private string GetPrefsKey(string key) => settingsPrefix + "." + key;
}
}
