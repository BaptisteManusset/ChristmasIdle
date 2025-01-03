using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[CustomEditor(typeof(TilesLibrary))]
public class TilesLibraryEditor : Editor
{
    private TilesLibrary m_library;
    private int rows = 4;

    private static Texture tileIcon;
    private static Texture ruleTileIcon;
    private static Texture siblingTileIcon;
    private static Texture otherTileIcon;

    private void OnEnable()
    {
        m_library = target as TilesLibrary;


        tileIcon = EditorGUIUtility.IconContent("d_CheckerFloor").image;
        ruleTileIcon = EditorGUIUtility.IconContent("_Popup").image;
        siblingTileIcon = EditorGUIUtility.IconContent("CustomTool").image;
        otherTileIcon = EditorGUIUtility.IconContent("CollabError").image;
    }

    private Texture GetIcon(TileBase a_tile)
    {
        if (a_tile.GetType() == typeof(Tile)) return tileIcon;
        if (a_tile.GetType() == typeof(RuleTile)) return ruleTileIcon;
        if (a_tile.GetType() == typeof(SiblingRuleTile)) return siblingTileIcon;


        return otherTileIcon;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Refresh"))
        {
            m_library.Populate();
        }
        
        if (m_library.Tiles.Any(x => x == null)) m_library.Populate();

        rows = (int)(EditorGUIUtility.currentViewWidth / 100);
        int count = 0;
        EditorGUILayout.BeginHorizontal();
        float width = EditorGUIUtility.currentViewWidth / rows - 10;
        foreach (TilesLibrary.TilebasePair pair in m_library.Tiles)
        {
            // GUI.color = Color.red;
            Element(width, pair);

            if (count % rows == rows - 1)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
            }

            count++;
        }

        EditorGUILayout.EndHorizontal();
    }

    private void Element(float dim, TilesLibrary.TilebasePair pair)
    {
        GUILayout.Label("",
            GUILayout.Width(dim),
            GUILayout.Height(dim)
        );

        Rect positions = GUILayoutUtility.GetLastRect();

        if (GUI.Button(positions, "", "Box"))
        {
            Selection.activeObject = pair.TileBase;
        }

        DrawTexturePreview(positions, pair.TileBase.GetTilePreview());
        positions.height = EditorGUIUtility.singleLineHeight * 2;
        string message = $"{pair.Key}\n{pair.TileBase.GetType().Name}";
        GUI.Label(positions, new GUIContent(pair.Key, GetIcon(pair.TileBase), message), "box");
    }

    private void DrawTexturePreview(Rect position, Sprite sprite)
    {
        if (!sprite)
        {
            GUI.DrawTexture(position, EditorGUIUtility.IconContent("BuildSettings.Broadcom").image);
            return;
        }

        Vector2 fullSize = new Vector2(sprite.texture.width, sprite.texture.height);
        Vector2 size = new Vector2(sprite.textureRect.width, sprite.textureRect.height);

        Rect coords = sprite.textureRect;
        coords.x /= fullSize.x;
        coords.width /= fullSize.x;
        coords.y /= fullSize.y;
        coords.height /= fullSize.y;

        Vector2 ratio;
        ratio.x = position.width / size.x;
        ratio.y = position.height / size.y;
        float minRatio = Mathf.Min(ratio.x, ratio.y);

        Vector2 center = position.center;
        position.width = size.x * minRatio;
        position.height = size.y * minRatio;
        position.center = center;

        GUI.DrawTextureWithTexCoords(position, sprite.texture, coords);
    }
}