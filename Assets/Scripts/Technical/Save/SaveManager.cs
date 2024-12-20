using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;


public class SaveManager : Singleton<SaveManager>
{
    private Tilemap m_tilemap;

    public SaveData CurrentSave;

    public event Action OnLoad;
    public event Action OnSave;

    protected override void Awake()
    {
        base.Awake();
        if (CurrentSave == null) CurrentSave = new SaveData();
    }

    [Button]
    public void Save()
    {
        List<Utils.TileAndPos> tiles = TilemapHandler.Instance.TileMap.GetTiles();
        CurrentSave = new SaveData(tiles, SettingManager.Instance.Setting);
        ES3.Save("save", CurrentSave);
    }

    [Button]
    public void LoadSave()
    {
        CurrentSave = ES3.Load<SaveData>("save");

        TilemapHandler.Instance.TileMap.ClearAllTiles();
        for (int i = 0; i < CurrentSave.Tiles.Count; i++)
        {
            TilemapHandler.Instance.TileMap.SetTile((Vector3Int)CurrentSave.Tiles[i].Position,
                CurrentSave.Tiles[i].Tile);
        }

        SettingManager.Instance.SetSetting(new Settings
        {
            CameraScale = CurrentSave.Setting.CameraScale,
            SnowflakeScale = CurrentSave.Setting.SnowflakeScale
        });
        OnLoad?.Invoke();
    }

    [Button]
    public void DeleteSave()
    {
        CurrentSave = null;
    }

    [Button]
    public void ClearTilemap()
    {
        TilemapHandler.Instance.TileMap.ClearAllTiles();
    }
}