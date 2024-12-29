using UnityEngine;
using UnityEngine.Tilemaps;

public class Placer : Tool
{
    private bool m_isPressed;

    protected override void Awake()
    {
        base.Awake();
        DisablePlacement();
    }

    public override void OnLeftStarted() => m_isPressed = true;

    public override void OnLeftCanceled() => m_isPressed = false;

    protected virtual void Update()
    {
        if (UiUtils.IsHover)
        {
            DisablePlacement();
            return;
        }

        TileBase tile = ToolsManager.Instance.GetCurrentTile();

        Tilemap tilemap = TilemapHandler.Instance.GetCurrentTilemap();
        CursorBackgroundHandler.Instance.SetPosition(tilemap.layoutGrid.GetMousePosition());

        if (!m_isPressed) return;

        Vector3Int tilePos = tilemap.layoutGrid.GetMousePosition();

        if (tile.GetType() == typeof(MobTile))
        {
            if (!tilemap.GetTile(tilePos))
            {
                tilemap.SetTile(tilePos, tile);
            }

            m_isPressed = false;
        }
        else
        {
            tilemap.SetTile(tilePos, tile);
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