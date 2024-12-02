using System;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Placer : Tool
{
    public bool IsPressed;

    public override void OnLeftStarted()
    {
        IsPressed = true;
    }

    public override void OnLeftCanceled()
    {
        IsPressed = false;
    }

    protected virtual void Update()
    {
        if (Utils.IsHoverUI()) return;
        if (IsPressed)
        {
            ToolsManager.Instance.tileMap.SetTile(ToolsManager.Instance.tileMap.layoutGrid.GetMousePosition(),
                ToolsManager.Instance.GetCurrentTilemap());
        }
    }
}