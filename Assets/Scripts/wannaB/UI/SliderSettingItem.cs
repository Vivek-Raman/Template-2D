using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace wannaB.UI
{
public class SliderSettingItem : SettingItem
{
    [SerializeField] private Slider slider;

    public void HandleSliderValueChanged(float value)
    {
        this.HandleSettingValueChanged(value.ToString(CultureInfo.InvariantCulture));
    }

    protected override void LoadSettingValueIntoUI(string value)
    {
        slider.SetValueWithoutNotify(float.Parse(value, CultureInfo.InvariantCulture));
    }
}
}
