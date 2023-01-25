using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace wannaB.UI
{
public abstract class SettingItem : MonoBehaviour
{
    [SerializeField] protected UnityEvent<string> onSettingValueChanged;
    [SerializeField] private string settingKey;
    [SerializeField] private string _settingDefaultValue;
    private string _settingValue;

    public string SettingKey => settingKey;
    public string SettingValue => _settingValue;
    public string SettingDefaultValue => _settingDefaultValue;


    private void OnValidate()
    {
        this.transform.GetChild(0).GetComponent<TMP_Text>().text = settingKey;
    }

    protected void HandleSettingValueChanged(string value)
    {
        this._settingValue = value;
        onSettingValueChanged?.Invoke(value);
    }

    public void LoadSettingValue(string value, bool loadIntoUI)
    {
        if (loadIntoUI)
        {
            this.LoadSettingValueIntoUI(value);
        }

        this.HandleSettingValueChanged(value);
    }

    protected abstract void LoadSettingValueIntoUI(string value);
}
}
