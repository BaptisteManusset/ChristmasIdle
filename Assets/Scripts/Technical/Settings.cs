using System;
using UnityEngine;

[Serializable]
public class Settings
{
    [SerializeField] private FloatRef m_snowFlakeScale;
    [SerializeField] private FloatRef m_cameraScale;
    [SerializeField] private BoolRef m_alwaysOnTop;


    public FloatRef CameraScale
    {
        get => m_cameraScale;
        set => m_cameraScale = value;
    }

    public FloatRef SnowflakeScale
    {
        get => m_snowFlakeScale;
        set => m_snowFlakeScale = value;
    }

    public BoolRef AlwaysOnTop
    {
        get => m_alwaysOnTop;
        set => m_alwaysOnTop = value;
    }

    public void SetValues(SettingsSaved a_setting)
    {
        CameraScale.Value = a_setting.CameraScale;
        SnowflakeScale.Value = a_setting.SnowflakeScale;
        AlwaysOnTop.Value = a_setting.AlwaysOnTop;
    }
}


[Serializable]
public class SettingsSaved
{
    [SerializeField] private float m_snowFlakeScale;
    [SerializeField] private float m_cameraScale;
    [SerializeField] private bool m_alwaysOnTop;


    public float CameraScale
    {
        get => m_cameraScale;
        set => m_cameraScale = value;
    }

    public float SnowflakeScale
    {
        get => m_snowFlakeScale;
        set => m_snowFlakeScale = value;
    }

    public bool AlwaysOnTop
    {
        get => m_alwaysOnTop;
        set => m_alwaysOnTop = value;
    }
}