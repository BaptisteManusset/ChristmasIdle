using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHandler : Singleton<TilemapHandler>
{
    [SerializeField] private GameObject WorldParent;
    [SerializeField] private Tilemap tileMap;

    [SerializeField] private GameObject UIParent;
    [SerializeField] private Tilemap menuMap;
    
    public Tilemap TileMap => tileMap;

    protected override void Awake()
    {
        base.Awake();
        UIParent.SetActive(false);
        WorldParent.SetActive(true);
    }

    public Tilemap GetCurrentTilemap()
    {
        return GameStateController.Instance.Current.State == EGameState.Menu ? menuMap : tileMap;
    }

    public void SwitchTilemap(bool a_showMenu)
    {
        UIParent.SetActive(a_showMenu);
        WorldParent.SetActive(!a_showMenu);
    }

    public bool IsWorldTilemap(ITilemap a_tilemapToTest)
    {
        return tileMap == a_tilemapToTest.GetComponent<Tilemap>();
    }
}