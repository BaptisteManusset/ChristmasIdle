using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    [SerializeField] private List<Utils.TileAndPos> m_tiles;
    [SerializeField] private SettingsSaved m_setting;

    public SaveData(List<Utils.TileAndPos> a_tiles, Settings a_setting)
    {
        m_tiles = a_tiles;
        m_setting = new SettingsSaved
        {
            SnowflakeScale = a_setting.SnowflakeScale,
            CameraScale = a_setting.CameraScale,
            AlwaysOnTop = a_setting.AlwaysOnTop
        };
    }

    public SaveData()
    {
        m_tiles = new List<Utils.TileAndPos>();
        m_setting = new SettingsSaved();
    }

    public List<Utils.TileAndPos> Tiles => m_tiles;

    public SettingsSaved Setting => m_setting;
}