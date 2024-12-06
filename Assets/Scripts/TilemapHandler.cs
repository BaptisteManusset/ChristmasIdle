using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHandler : Singleton<TilemapHandler>
{
    [SerializeField] private GameObject WorldParent;
    [SerializeField] private Tilemap tileMap;

    [SerializeField] private GameObject UIParent;
    [SerializeField] private Tilemap menuMap;

    [SerializeField] private TMP_Text m_currentTilemap;

    public Tilemap GetCurrentTilemap()
    {
        return GameStateController.Instance.Current.State == EGameState.Menu ? menuMap : tileMap;
    }

    public void SwitchTilemap(bool a_showMenu)
    {
        UIParent.gameObject.SetActive(a_showMenu);
        WorldParent.gameObject.SetActive(!a_showMenu);
    }
}