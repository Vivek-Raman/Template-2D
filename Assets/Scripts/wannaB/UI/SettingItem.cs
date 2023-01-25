using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace wannaB.UI
{
public abstract class SettingItem : MonoBehaviour
{
    [SerializeField] protected UnityEvent<object> onSettingValueChanged;
    [SerializeField] private string settingKey;
    private string _settingValue;

    public Tuple<string, string> SettingData => new (settingKey, _settingValue);

    private void OnValidate()
    {
        this.transform.GetChild(0).GetComponent<TMP_Text>().text = settingKey;
    }

    protected void HandleSettingValueChanged(string value)
    {
        this._settingValue = value;
        onSettingValueChanged?.Invoke(value);
    }

    public void LoadDefaultValue(string value, bool loadIntoUI)
    {
        if (loadIntoUI)
        {
            this.LoadDefaultValueIntoUI(value);
        }

        this.HandleSettingValueChanged(value);
    }

    protected abstract void LoadDefaultValueIntoUI(string value);
}
}
