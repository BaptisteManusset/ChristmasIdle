using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShopList : MonoBehaviour
{
    public List<TileBase> m_tiles = new();

    
    [ContextMenu("Test")]
    private void Start()
    {
        // for (int i = 0; i < m_tiles.Count; i++)
        // {
        //     if (m_tiles[i] is Tile tileData)
        //     {
        //         Debug.Log($"{m_tiles[i].name}  >  {tileData.sprite}");
        //     }
        //     else if (m_tiles[i] is RuleTile ruleTile)
        //     {
        //         Debug.Log($"{m_tiles[i].name}  >  {ruleTile.m_DefaultSprite}");
        //     }
        //     else if (m_tiles[i] is AnimatedTile animatedTile)
        //     {
        //         Debug.Log($"{m_tiles[i].name}  >  {animatedTile.m_AnimatedSprites.First()}");
        //     }
        // }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}