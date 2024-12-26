using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    [SerializeField] private List<Utils.TileAndPos> m_tiles;
    [SerializeField] private Settings m_setting;

    public SaveData(List<Utils.TileAndPos> a_tiles, Settings a_setting)
    {
        m_tiles = a_tiles;
        m_setting = a_setting;
    }

    public SaveData()
    {
        m_tiles = new List<Utils.TileAndPos>();
        m_setting = new Settings();
    }

    public List<Utils.TileAndPos> Tiles => m_tiles;

    public Settings Setting => m_setting;
}