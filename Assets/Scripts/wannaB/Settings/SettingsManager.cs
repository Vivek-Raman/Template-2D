using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace wannaB.Settings
{
public class SettingsManager : MonoBehaviour
{
    [SerializeField] private string settingsPrefix;

    private List<SettingItem> _settings;
    public Dictionary<SettingKey, SettingItem> Settings => _settings.ToDictionary(item => item.SettingKey);

    private void Awake()
    {
        _settings = new List<SettingItem>(this.GetComponentsInChildren<SettingItem>());
    }

    public void SaveSettings()
    {
        foreach (SettingItem item in _settings)
        {
            PlayerPrefs.SetString(GetPrefsKey(item.SettingKey), item.SettingValue);
        }

        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        foreach (SettingItem item in _settings)
        {
            string newValue = PlayerPrefs.GetString(GetPrefsKey(item.SettingKey), item.SettingDefaultValue);
            item.LoadSettingValue(newValue);
        }
    }

    public void TrySaveFirstLaunchSettings()
    {
        if (bool.Parse(PlayerPrefs.GetString(GetPrefsKey(SettingKey.ReturningPlayer), "false"))) return;
        foreach (SettingItem item in _settings)
        {
            PlayerPrefs.SetString(GetPrefsKey(item.SettingKey), item.SettingDefaultValue);
        }

        PlayerPrefs.SetString(GetPrefsKey(SettingKey.ReturningPlayer), "true");
        PlayerPrefs.Save();
    }

    private string GetPrefsKey(SettingKey key) => settingsPrefix + "." + key.ToString();
}
}
