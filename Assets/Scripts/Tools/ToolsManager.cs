using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ToolsManager : Singleton<ToolsManager>
{
    private List<Tool> m_tools = new();

    public Tool current;


    [SerializeField] InputAction LeftDown = new();
    [SerializeField] InputAction RightDown = new();


    [SerializeField] private TileBase currentTile;

    [SerializeField] private TMP_Text m_currentTilemap;
    [SerializeField] private TMP_Text m_currentTool;


    public void SetCurrentTilemap(TileBase a_tile)
    {
        currentTile = a_tile;
        m_currentTilemap.text = currentTile.GetType().Name;
    }

    public TileBase GetCurrentTilemap()
    {
        return currentTile;
    }

    public void SetCurrentTool(Tool a_tool)
    {
        if (current) current.OnDeselect();
        current = a_tool;
        if (current) current.OnSelect();

        m_currentTool.text = current.GetType().Name;
    }

    #region Awake

    protected override void Awake()
    {
        base.Awake();
        m_tools.AddRange(GetComponents<Tool>());

        LeftDown.Enable();
        LeftDown.started += OnLeftStarted;
        LeftDown.performed += OnLeftPerformed;
        LeftDown.canceled += OnLeftCanceled;
        RightDown.started += OnRightStarted;
        RightDown.performed += OnRightPerformed;
        RightDown.canceled += OnRightCanceled;
    }

    private void OnDestroy()
    {
        LeftDown.started -= OnLeftStarted;
        LeftDown.performed -= OnLeftPerformed;
        LeftDown.canceled -= OnLeftCanceled;
        RightDown.started -= OnRightStarted;
        RightDown.performed -= OnRightPerformed;
        RightDown.canceled -= OnRightCanceled;
    }

    #endregion


    #region events

    private void OnLeftCanceled(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnLeftCanceled();
    }

    private void OnLeftPerformed(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnLeftPerformed();
    }

    private void OnLeftStarted(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnLeftStarted();
    }

    private void OnRightCanceled(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnRightCanceled();
    }

    private void OnRightPerformed(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnRightPerformed();
    }

    private void OnRightStarted(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnRightStarted();
    }

    #endregion
}