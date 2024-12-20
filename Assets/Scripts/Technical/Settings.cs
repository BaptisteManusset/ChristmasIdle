﻿using System;
using UnityEngine;

[Serializable]
public class Settings
{
    [SerializeField] private float m_cameraScale = 0;
    [SerializeField] private float m_snowflakeScale = 0;

    public float CameraScale
    {
        get => m_cameraScale;
        set => m_cameraScale = value;
    }

    public float SnowflakeScale
    {
        get => m_snowflakeScale;
        set => m_snowflakeScale = value;
    }
}