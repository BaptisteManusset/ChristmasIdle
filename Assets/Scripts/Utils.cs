using System;
using System.Collections.Generic;
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

    // public static T[] GetTiles<T>(this Tilemap tilemap) where T : TileBase
    // {
    //     List<T> tiles = new List<T>();
    //
    //     for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
    //     {
    //         for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
    //         {
    //             T tile = tilemap.GetTile<T>(new Vector3Int(x, y, 0));
    //             if (tile != null)
    //             {
    //                 tiles.Add(tile);
    //             }
    //         }
    //     }
    //
    //     return tiles.ToArray();
    // }

    public static List<TileAndPos> GetTiles(this Tilemap tilemap)
    {
        List<TileAndPos> tiles = new List<TileAndPos>();

        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                TileBase tile = tilemap.GetTile<TileBase>(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    tiles.Add(new TileAndPos(tile, new Vector2Int(x, y)));
                }
            }
        }

        return tiles;
    }

    [Serializable]
    public class TileAndPos
    {
        [SerializeField] private TileBase m_tile;
        [SerializeField] private Vector2Int m_position;

        public TileAndPos(TileBase a_tile, Vector2Int a_position)
        {
            m_tile = a_tile;
            m_position = a_position;
        }

        public TileBase Tile => m_tile;

        public Vector2Int Position => m_position;
    }
}