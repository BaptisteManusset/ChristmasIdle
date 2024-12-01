using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

[CustomEditor(typeof(ShopList))]
public class ShopListEditor : Editor
{
    private ShopList shop;

    private void OnEnable()
    {
        shop = target as ShopList;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        for (int i = 0; i < shop.m_tiles.Count; i++)
        {
            Sprite sprite = shop.m_tiles[i] switch
            {
                Tile temp => temp.sprite,
                RuleTile temp => temp.m_DefaultSprite,
                RuleOverrideTile temp => temp.m_Sprites.First().m_OverrideSprite,
                AnimatedTile temp => temp.m_AnimatedSprites.First(),
                _ => null
            };

            Texture2D texture = AssetPreview.GetAssetPreview(sprite);

            using (new GUILayout.HorizontalScope("Box"))
            {
                GUILayout.Label(shop.m_tiles[i].name);
                GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
                GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
            }
        }
    }
}