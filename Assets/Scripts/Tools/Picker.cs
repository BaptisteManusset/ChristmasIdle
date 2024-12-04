using UnityEngine.Tilemaps;

public class Picker : Tool
{
    public override void OnLeftStarted()
    {
        if (Utils.IsHoverUI() && GameStateController.Instance.Current.State == EGameState.Ingame) return;
        TileBase tileBase = TilemapHandler.Instance.GetTilemap().GetTileFromMousePosition();
        if (tileBase == null) return;
        ToolsManager.Instance.SetCurrentTilemap(tileBase);
        ToolsManager.Instance.SetPlacer();
    }
}