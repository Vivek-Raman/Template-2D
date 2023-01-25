using System;
using UnityEngine;

namespace wannaB.Utility
{
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isLoaded = false;

    public static T Instance
    {
        get
        {
            if (!_isLoaded)
            {
                _instance = FindObjectOfType<T>();
                _isLoaded = true;
            }
            return _instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
}
