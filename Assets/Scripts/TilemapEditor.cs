using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TilemapEditor : MonoBehaviour
{
    public Tilemap shopTilemap;
    private Tilemap tileMap;
    private bool m_ismainNull;
    private Grid grid;

    public TileBase currentTile;

    public InputAction leftClick;
    public InputAction rightClick;

    public TMP_Text current;

    private void Awake()
    {
        grid = GetComponent<Grid>();
        tileMap = GetComponentInChildren<Tilemap>();

        leftClick.Enable();
        leftClick.performed += LeftClickPerformed;

        rightClick.Enable();
        rightClick.performed += RightClickPerformed;
    }

    private void RightClickPerformed(InputAction.CallbackContext a_obj)
    {
        TileBase pickerTile =
            Shop.IsOpen ? shopTilemap.GetTile(grid.GetMousePosition()) : tileMap.GetTile(grid.GetMousePosition());

        if (pickerTile == null) return;
        currentTile = pickerTile;
        current.text = currentTile.name;
    }

    private void LeftClickPerformed(InputAction.CallbackContext a_obj)
    {
    }
}