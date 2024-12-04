using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TilemapEditor : MonoBehaviour
{
    public Tilemap shopTilemap;
    private bool m_ismainNull;

    // public TileBase currentTile;

    public InputAction leftClick;
    public InputAction rightClick;

    private void Awake()
    {
        GetComponent<Grid>();
        GetComponentInChildren<Tilemap>();

        leftClick.Enable();
        leftClick.performed += LeftClickPerformed;

        rightClick.Enable();
        rightClick.performed += RightClickPerformed;
    }

    private void RightClickPerformed(InputAction.CallbackContext a_obj)
    {
        // TileBase pickerTile =
        //     Shop.IsOpen ? shopTilemap.GetTile(grid.GetMousePosition()) : tileMap.GetTile(grid.GetMousePosition());

        // if (pickerTile == null) return;
        // currentTile = pickerTile;
        // current.text = currentTile.name;
    }

    private void LeftClickPerformed(InputAction.CallbackContext a_obj)
    {
    }
}