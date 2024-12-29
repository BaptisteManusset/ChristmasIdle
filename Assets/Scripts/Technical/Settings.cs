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
}