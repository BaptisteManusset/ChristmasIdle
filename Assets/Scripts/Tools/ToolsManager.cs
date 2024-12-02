using System;
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

    [SerializeField] private TMP_Text m_label;
    public Tilemap tileMap;

    public void SetCurrentTilemap(TileBase a_tile)
    {
        currentTile = a_tile;
        m_label.text = currentTile.GetType().Name;
    }

    public TileBase GetCurrentTilemap()
    {
        return currentTile;
    }

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

    public bool hoverUi;

    private void Update()
    {
        hoverUi = Utils.IsHoverUI();
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

    public void SetCurrentTool(Tool a_tool)
    {
        current = a_tool;
    }

    private void OnLeftCanceled(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnLeftCanceled();
        Debug.Log("OnLeftCanceled");
    }

    private void OnLeftPerformed(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnLeftPerformed();
        Debug.Log("OnLeftPerformed");
    }

    private void OnLeftStarted(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnLeftStarted();
        Debug.Log("OnLeftStarted");
    }

    private void OnRightCanceled(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnRightCanceled();
        Debug.Log("OnRightCanceled");
    }

    private void OnRightPerformed(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnRightPerformed();
        Debug.Log("OnRightPerformed");
    }

    private void OnRightStarted(InputAction.CallbackContext a_obj)
    {
        if (current == null) return;
        current.OnRightStarted();
        Debug.Log("OnRightStarted");
    }
}