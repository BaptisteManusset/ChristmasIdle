public class Eraser : Placer
{
    protected override void Update()
    {
        if (Utils.IsHoverUI()) return;
        if (IsPressed)
        {
            ToolsManager.Instance.tileMap.SetTile(ToolsManager.Instance.tileMap.layoutGrid.GetMousePosition(), null);
        }
    }
}