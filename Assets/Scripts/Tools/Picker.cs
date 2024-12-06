using UnityEngine.Tilemaps;

public class Picker : Tool
{
    public override void OnLeftStarted()
    {
        if (!CanPick()) return;

        TileBase tileBase = TilemapHandler.Instance.GetCurrentTilemap().GetTileFromMousePosition();
        if (tileBase == null) return;
        ToolsManager.Instance.SetCurrentTilemap(tileBase);
        ToolsManager.Instance.SetPlacer();
    }

    private bool CanPick()
    {
        return (GameStateController.Instance.Current.State == EGameState.EditState && !UiUtils.IsHover) ||
               GameStateController.Instance.Current.State == EGameState.Menu;
    }
}