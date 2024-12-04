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
        if (GameStateController.Instance.Current.State == EGameState.Menu)
        {
            Debug.Log("menu map");
            return menuMap;
        }

        Debug.Log("world map");
        return tileMap;
    }
}