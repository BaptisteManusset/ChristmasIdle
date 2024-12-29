using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class TilePreview : MonoBehaviour
{
    [SerializeField] private Image m_preview;
    [SerializeField] private TMP_Text m_label;


    private void OnEnable()
    {
        ToolsManager.Instance.CurrentTileChanged += CurrentTileChanged;
        CurrentTileChanged(ToolsManager.Instance.GetCurrentTile());
    }

    private void OnDisable()
    {
        ToolsManager.Instance.CurrentTileChanged -= CurrentTileChanged;
    }

    private void CurrentTileChanged(TileBase a_tile)
    {
        m_preview.enabled = a_tile != null;
        m_preview.sprite = a_tile.GetTilePreview();
        m_label.text = a_tile.name;
    }
}