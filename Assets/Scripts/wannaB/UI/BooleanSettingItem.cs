using UnityEngine;
using UnityEngine.UI;

namespace wannaB.UI
{
public class BooleanSettingItem : SettingItem
{
    [SerializeField] private Toggle toggle;

    public void HandleToggleValueChanged(bool value)
    {
        this.HandleSettingValueChanged(value.ToString());
    }

    protected override void LoadSettingValueIntoUI(string value)
    {
        toggle.SetIsOnWithoutNotify(bool.Parse(value));
    }
}
}
