using UnityEngine;
using UnityEngine.Tilemaps;

public class Placer : Tool
{
    private bool m_isPressed;
    [SerializeField] private GameObject m_placement;

    protected override void Awake()
    {
        base.Awake();
        DisablePlacement();
    }


    private void OnGameStateChanged(EGameState a_state)
    {
        switch (a_state)
        {
            case EGameState.EditState:
                EnablePlacement();
                break;
            case EGameState.Menu:
                DisablePlacement();
                break;
            case EGameState.Idle:
                DisablePlacement();
                break;
        }
    }

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
        if (UiUtils.IsHover)
        {
            m_placement.gameObject.SetActive(false);
            return;
        }

        TileBase tile = ToolsManager.Instance.GetCurrentTile();

        Tilemap tilemap = TilemapHandler.Instance.GetCurrentTilemap();
        m_placement.transform.position = tilemap.layoutGrid.GetMousePosition();

        if (!m_isPressed) return;
        tilemap.SetTile(tilemap.layoutGrid.GetMousePosition(), tile);

        if (tile.GetType() == typeof(MobTile))
        {
            m_isPressed = false;
        }
    }

    public override void OnSelect()
    {
        base.OnSelect();
        m_placement.SetActive(true);
        UiUtils.OnEnterUi += DisablePlacement;
        UiUtils.OnExitUi += EnablePlacement;
    }

    public override void OnDeselect()
    {
        base.OnDeselect();
        m_placement.SetActive(false);
        UiUtils.OnEnterUi -= DisablePlacement;
        UiUtils.OnExitUi -= EnablePlacement;
    }

    private void DisablePlacement()
    {
        m_placement.gameObject.SetActive(false);
    }

    private void EnablePlacement()
    {
        m_placement.gameObject.SetActive(true);
    }
}