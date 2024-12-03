using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHandler : Singleton<TilemapHandler>
{
    [SerializeField] Tilemap tileMap;
    [SerializeField] Tilemap menuMap;
    [SerializeField] private TMP_Text m_currentTilemap;

    public Tilemap GetTilemap()
    {
        return GameStateController.Instance.Current.GetType() == typeof(UiState) ? menuMap : tileMap;
    }

}