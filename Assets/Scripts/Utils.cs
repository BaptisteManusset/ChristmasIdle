using System.Linq;
using UnityEngine;
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

    /// <summary>
    /// Get tile from a worldspace position
    /// </summary>
    public static TileBase GetTileWorld(this Tilemap a_tilemap, Vector3 a_position)
    {
        Vector3Int coor = a_tilemap.WorldToCell(a_position);
        return a_tilemap.GetTile(coor);
    }

    // public static TileBase GetUpTile(this  Tilemap a_tilemap, TileBase a_tile)
    // {
    //     a_tilemap.get
    //     
    //     return a_tile.
    // }

    public static Sprite GetTilePreview(this TileBase a_tile)
    {
        Sprite sprite = a_tile switch
        {
            Tile temp => temp.sprite,
            RuleTile temp => temp.m_DefaultSprite,
            RuleOverrideTile temp => temp.m_Sprites.First().m_OverrideSprite,
            AnimatedTile temp => temp.m_AnimatedSprites.First(),
            _ => null
        };
        return sprite;
    }
}