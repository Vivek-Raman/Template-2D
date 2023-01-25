using System;
using UnityEngine;
using wannaB.Audio;
using wannaB.Settings;
using wannaB.Utility;

namespace wannaB
{
[RequireComponent(typeof(SettingsManager))]
[RequireComponent(typeof(AudioManager))]
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private SettingsManager _settingsManager;

    public override void Awake()
    {
        base.Awake();

        _settingsManager = this.GetComponent<SettingsManager>();

        _settingsManager.TrySaveFirstLaunchSettings();
        _settingsManager.LoadSettings(false);
    }
}
}
