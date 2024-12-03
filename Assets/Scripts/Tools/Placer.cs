using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Placer : Tool
{
    private bool m_isPressed;
    [SerializeField] private GameObject m_placement;

    public override void OnLeftStarted()
    {
        m_isPressed = true;
    }

    public override void OnLeftCanceled()
    {
        m_isPressed = false;
    }

    protected virtual void Update()
    {
        if (Utils.IsHoverUI())
        {
            m_placement.gameObject.SetActive(false);
            return;
        }


        if (!m_isPressed) return;
        Tilemap tilemap = TilemapHandler.Instance.GetTilemap();
        m_placement.transform.position = tilemap.layoutGrid.GetMousePosition();
        tilemap.SetTile(tilemap.layoutGrid.GetMousePosition(), ToolsManager.Instance.GetCurrentTilemap());
    }

    public override void OnSelect()
    {
        Debug.Log("OnSelect");
        m_placement.SetActive(true);
    }

    public override void OnDeselect()
    {
        Debug.Log("OnDeselect");
        m_placement.SetActive(false);
    }
}