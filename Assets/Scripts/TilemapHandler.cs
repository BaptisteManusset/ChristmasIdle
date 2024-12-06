using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHandler : Singleton<TilemapHandler>
{
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Tilemap menuMap;
    [SerializeField] private TMP_Text m_currentTilemap;

    public Tilemap GetTilemap()
    {
        return GameStateController.Instance.Current.State == EGameState.Menu ? menuMap : tileMap;
    }
}