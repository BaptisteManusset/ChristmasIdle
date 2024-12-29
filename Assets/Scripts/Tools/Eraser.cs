using UnityEngine.Tilemaps;

public class Eraser : Tool
{
    private bool m_isPressed;

    public override void OnLeftStarted()
    {
        m_isPressed = true;
    }

    public override void OnLeftCanceled()
    {
        m_isPressed = false;
    }

    protected virtual void Update()
    {
        if (UiUtils.IsHover)
        {
            DisablePlacement();
            return;
        }

        Tilemap tilemap = TilemapHandler.Instance.GetCurrentTilemap();
        CursorBackgroundHandler.Instance.SetPosition(tilemap.layoutGrid.GetMousePosition());

        if (m_isPressed)
        {
            TilemapHandler.Instance.GetCurrentTilemap()
                .SetTile(TilemapHandler.Instance.GetCurrentTilemap().layoutGrid.GetMousePosition(), null);
        }
    }

    public override void OnSelect()
    {
        base.OnSelect();
        EnablePlacement();
        UiUtils.OnEnterUi += DisablePlacement;
        UiUtils.OnExitUi += EnablePlacement;
    }

    public override void OnDeselect()
    {
        base.OnDeselect();
        DisablePlacement();
        UiUtils.OnEnterUi -= DisablePlacement;
        UiUtils.OnExitUi -= EnablePlacement;
    }

    private void DisablePlacement() => CursorBackgroundHandler.Instance.Hide();

    private void EnablePlacement() => CursorBackgroundHandler.Instance.Show();
}