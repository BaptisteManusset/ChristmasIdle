using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TilemapEditor : MonoBehaviour
{
    public Tilemap shopTilemap;
    private Tilemap tileMap;
    private bool m_ismainNull;
    private Grid grid;

    public GameObject Placement;
    public TileBase currentTile;

    public InputAction leftClick;
    public InputAction rightClick;

    public TMP_Text current;

    public Button m_erase;

    private void Awake()
    {
        grid = GetComponent<Grid>();
        tileMap = GetComponentInChildren<Tilemap>();

        leftClick.Enable();
        leftClick.performed += LeftClickPerformed;

        rightClick.Enable();
        rightClick.performed += RightClickPerformed;

        m_erase.onClick.AddListener(Erase);
    }

    private void Erase()
    {
        currentTile = null;
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


    public void Update()
    {
        // if (leftClick.IsPressed())
        // {
        //     grid.GetMousePosition();
        //     tileMap.SetTile(grid.GetMousePosition(), currentTile);
        // }

        Placement.transform.position = grid.GetMousePosition();
    }
}