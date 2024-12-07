using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class MobTile : RuleTile<MobTile.Neighbor>
{
    public GameObject m_mob;

    private bool m_instantiate;
    private int count = 0;
    private static readonly Vector3 Position = new(.5f, .5f);

    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Null = 3;
        public const int NotNull = 4;
    }

    public override bool RuleMatch(int a_neighbor, TileBase a_tile)
    {
        switch (a_neighbor)
        {
            case Neighbor.Null: return a_tile == null;
            case Neighbor.NotNull: return a_tile != null;
        }

        return base.RuleMatch(a_neighbor, a_tile);
    }

    public override void GetTileData(Vector3Int a_position, ITilemap a_tilemap, ref TileData a_tileData)
    {
        if (TilemapHandler.Instance.IsWorldTilemap(a_tilemap))
        {
            Debug.Log($"{a_position} count: {count}");
            Tilemap tilemap = a_tilemap.GetComponent<Tilemap>();
            Instantiate(m_mob, a_position + Position, quaternion.identity, tilemap.transform);
            tilemap.SetTile(a_position, null);
            count++;
        }

        base.GetTileData(a_position, a_tilemap, ref a_tileData);
    }

    public override bool StartUp(Vector3Int a_position, ITilemap a_tilemap, GameObject a_instantiatedGameObject)
    {
        return base.StartUp(a_position, a_tilemap, a_instantiatedGameObject);
    }

    public override void RefreshTile(Vector3Int a_position, ITilemap a_tilemap)
    {
        Debug.Log($"RefreshTile: {a_position}  {a_tilemap}");
        base.RefreshTile(a_position, a_tilemap);
    }
}