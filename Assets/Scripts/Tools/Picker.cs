using UnityEngine;
using UnityEngine.Tilemaps;

public class Picker : Tool
{
    public Tilemap m_tilemap;

    public override void OnLeftStarted()
    {
        if (Utils.IsHoverUI()) return;
        TileBase b = m_tilemap.GetTileFromMousePosition();
        if (b == null) return;
        Debug.Log(b);
        ToolsManager.Instance.SetCurrentTilemap(b);
    }
}