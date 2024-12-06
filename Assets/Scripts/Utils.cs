using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public static class Utils
{
 
    
    public static Vector3Int GetMousePosition(this Grid a_grid)
    {
        // save the camera as public field if you using not the main camera
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        // get the collision point of the ray with the z = 0 plane
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        return a_grid.WorldToCell(worldPoint);
    }

    public static TileBase GetTileFromMousePosition(this Tilemap a_tilemap)
    {
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            return a_tilemap.GetTile(a_tilemap.WorldToCell(worldPoint));
        }

        return null;
    }


}