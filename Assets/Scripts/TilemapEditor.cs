using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapEditor : MonoBehaviour
{
    public Tilemap tileMap;
    private bool m_ismainNull;
    Grid grid;

    public TileBase Tile;

    private void Awake()
    {
        grid = GetComponent<Grid>();
        tileMap = GetComponentInChildren<Tilemap>();
    }

    Vector3Int position;

    public void Update()
    {
        // save the camera as public field if you using not the main camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // get the collision point of the ray with the z = 0 plane
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        position = grid.WorldToCell(worldPoint);
        TileBase tileToPlace = tileMap.GetTile(position);

        Debug.Log(tileToPlace ? tileToPlace.name : "");
        if (Input.GetMouseButtonUp(0))
        {
            tileMap.SetTile(position, Tile);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Tile = tileMap.GetTile(position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(position, .1f);
    }
}