﻿public class Eraser : Tool
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
        if (UiUtils.IsHover) return;
        if (m_isPressed)
        {
            TilemapHandler.Instance.GetCurrentTilemap()
                .SetTile(TilemapHandler.Instance.GetCurrentTilemap().layoutGrid.GetMousePosition(), null);
        }
    }
}