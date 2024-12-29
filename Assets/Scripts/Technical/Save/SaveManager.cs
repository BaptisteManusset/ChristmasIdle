using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;


public class SaveManager : Singleton<SaveManager>
{
    public TilesLibrary Library;
    public const string FILEPATH = "SAVE.SAV";

    private Tilemap m_tilemap;

    public SaveData CurrentSave;

    public event Action OnLoad;
    public event Action OnSave;

    protected override void Awake()
    {
        base.Awake();
        if (CurrentSave == null) CurrentSave = new SaveData();
    }

#if UNITY_EDITOR
    [Button]
#endif
    public void Save()
    {
        List<Utils.TileAndPos> tiles = TilemapHandler.Instance.TileMap.GetTiles();
        CurrentSave = new SaveData(tiles, SettingManager.Instance.Setting);
        ES3.Save("save", CurrentSave, FILEPATH);
    }

#if UNITY_EDITOR
    [Button]
#endif
    public void LoadSave()
    {
        CurrentSave = ES3.Load<SaveData>("save", FILEPATH);

        TilemapHandler.Instance.TileMap.ClearAllTiles();
        for (int i = 0; i < CurrentSave.Tiles.Count; i++)
        {
            TileBase tile = Library.GetTile(CurrentSave.Tiles[i].Tile);
            Vector3Int pos = (Vector3Int)CurrentSave.Tiles[i].Position;
            TilemapHandler.Instance.TileMap.SetTile(pos, tile);
        }

        SettingManager.Instance.SetSetting(CurrentSave.Setting);
        OnLoad?.Invoke();
    }

#if UNITY_EDITOR
    [Button]
#endif
    public void DeleteSave()
    {
        CurrentSave = null;
    }

#if UNITY_EDITOR
    [Button]
#endif
    public void ClearTilemap()
    {
        TilemapHandler.Instance.TileMap.ClearAllTiles();
    }

    public void AddKey(string a_key, object a_value)
    {
    }
}