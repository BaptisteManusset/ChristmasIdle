using UnityEngine;
using UnityEngine.Tilemaps;

public class Picker : Tool
{

    public override void OnLeftStarted()
    {
        if (Utils.IsHoverUI()) return;
        TileBase tileBase = TilemapHandler.Instance.GetTilemap().GetTileFromMousePosition();
        if (tileBase == null) return;
        Debug.Log(tileBase);
        ToolsManager.Instance.SetCurrentTilemap(tileBase);
    }
}