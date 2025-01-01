using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TilePreview : MonoBehaviour
{
    [SerializeField] private Image m_preview;
    [SerializeField] private TMP_Text m_label;

    [SerializeField] private TileRef m_tileRef;

    private void OnEnable()
    {
        m_tileRef.ValueChanged += CurrentTileChanged;
        CurrentTileChanged();
    }

    private void OnDisable()
    {
        m_tileRef.ValueChanged -= CurrentTileChanged;
    }

    private void CurrentTileChanged()
    {
        if (m_tileRef == null)
        {
            m_preview.sprite = null;
            m_label.text = "";
            return;
        }

        m_preview.sprite = m_tileRef.Value.GetTilePreview();
        m_label.text = m_tileRef.Value.name;
    }
}