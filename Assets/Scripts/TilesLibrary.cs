using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using NaughtyAttributes;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tiles Library", menuName = "Tiles Library", order = 0)]
public class TilesLibrary : ScriptableObject
{
    [Serializable]
    public class TilebasePair
    {
        public string Key;
        public TileBase TileBase;

        public TilebasePair(TileBase a_tile)
        {
            Key = a_tile.name;
            TileBase = a_tile;
        }
    }


    [SerializeField] private List<TilebasePair> m_tiles = new();
    public List<TilebasePair> Tiles => m_tiles;

#if UNITY_EDITOR
    [Button]
#endif
    [ContextMenu("Populate")]
    public void Populate()
    {
#if UNITY_EDITOR
        string[] guids = AssetDatabase.FindAssets("t=tilebase");
        m_tiles.Clear();
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            TileBase tile = AssetDatabase.LoadAssetAtPath<TileBase>(path);
            m_tiles.Add(new TilebasePair(tile));
        }

        Debug.Log($"Update {nameof(TilesLibrary)}");
#endif
    }

    public TileBase GetTile(string a_tile)
    {
        foreach (TilebasePair tile in m_tiles)
        {
            if (tile.Key == a_tile)
            {
                return tile.TileBase;
            }
        }

        return null;
    }
}

#if UNITY_EDITOR
public class CustomImportSettings : AssetPostprocessor
{
    private void OnPreprocessModel()
    {
        TextureImporter importer = (TextureImporter)assetImporter;
        if (importer)
        {
            TilesLibrary library = Utils.LoadAsset<TilesLibrary>().First();
            library.Populate();
        }
    }
}
#endif