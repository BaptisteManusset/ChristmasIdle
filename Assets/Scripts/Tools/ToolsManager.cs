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


    [SerializeField] private InputAction LeftDown = new();
    [SerializeField] private InputAction RightDown = new();


    [SerializeField] private TileBase currentTile;

    [SerializeField] private TMP_Text m_currentTilemap;
    [SerializeField] private TMP_Text m_currentTool;


    [SerializeField] private Picker m_picker;
    [SerializeField] private Placer m_placer;
    [SerializeField] private Eraser m_eraser;

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

        m_currentTool.text = current.name;
    }

    public void SetEraser() => SetCurrentTool(m_eraser);
    public void SetPlacer() => SetCurrentTool(m_placer);
    public void SetPicker() => SetCurrentTool(m_picker);


    #region Awake

    protected override void Awake()
    {
        m_eraser = GetComponent<Eraser>();
        m_placer = GetComponent<Placer>();
        m_picker = GetComponent<Picker>();
        ((GameStateController)GameStateController.Instance).OnGameStateChange += OnGameStateChange;

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

    private void OnGameStateChange(EGameState a_state)
    {
        switch (a_state)
        {
            case EGameState.EditState:
                LeftDown.Enable();
                RightDown.Enable();
                break;
            case EGameState.Menu:
                LeftDown.Disable();
                RightDown.Disable();
                break;
            case EGameState.Idle:
                LeftDown.Disable();
                RightDown.Disable();
                break;
        }
    }

    private void OnDestroy()
    {
        LeftDown.started -= OnLeftStarted;
        LeftDown.performed -= OnLeftPerformed;
        LeftDown.canceled -= OnLeftCanceled;
        RightDown.started -= OnRightStarted;
        RightDown.performed -= OnRightPerformed;
        RightDown.canceled -= OnRightCanceled;

        ((GameStateController)GameStateController.Instance).OnGameStateChange -= OnGameStateChange;
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