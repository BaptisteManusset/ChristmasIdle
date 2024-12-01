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
        TileBase pickerTile = Shop.IsOpen ? shopTilemap.GetTile(GetPosition()) : tileMap.GetTile(GetPosition());

        if (pickerTile == null) return;
        currentTile = pickerTile;
        current.text = currentTile.name;
    }

    private void LeftClickPerformed(InputAction.CallbackContext a_obj)
    {
    }


    public void Update()
    {
        if (leftClick.IsPressed())
        {
            GetPosition();
            tileMap.SetTile(GetPosition(), currentTile);
        }

        Placement.transform.position = GetPosition();
    }

    private Vector3Int GetPosition()
    {
        // save the camera as public field if you using not the main camera
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        // get the collision point of the ray with the z = 0 plane
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        return grid.WorldToCell(worldPoint);
    }
}