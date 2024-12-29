using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ToolsManager : Singleton<ToolsManager>
{
    [SerializeField] Tool current;

    public Tool CurrentTool => current;

    [SerializeField] private InputAction LeftDown = new();
    [SerializeField] private InputAction RightDown = new();


    [SerializeField] private TileRef currentTile;

    private Picker m_picker;
    private Placer m_placer;
    private Eraser m_eraser;

    #region Awake

    protected override void Awake()
    {
        m_eraser = GetComponent<Eraser>();
        m_placer = GetComponent<Placer>();
        m_picker = GetComponent<Picker>();

        base.Awake();

        LeftDown.Enable();
        LeftDown.started += OnLeftStarted;
        LeftDown.performed += OnLeftPerformed;
        LeftDown.canceled += OnLeftCanceled;
        RightDown.started += OnRightStarted;
        RightDown.performed += OnRightPerformed;
        RightDown.canceled += OnRightCanceled;

        LeftDown.Enable();
        RightDown.Enable();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        LeftDown.started -= OnLeftStarted;
        LeftDown.performed -= OnLeftPerformed;
        LeftDown.canceled -= OnLeftCanceled;
        RightDown.started -= OnRightStarted;
        RightDown.performed -= OnRightPerformed;
        RightDown.canceled -= OnRightCanceled;
    }

    #endregion

    public void SetCurrentTile(TileBase a_tile)
    {
        currentTile.Value = a_tile;
    }

    public void SetTool(Tool a_tool)
    {
        if (current) current.OnDeselect();

        current = a_tool;
        if (!current) return;
        current.OnSelect();
    }

    public void SetEraser() => SetTool(m_eraser);
    public void SetPlacer() => SetTool(m_placer);
    public void SetPicker() => SetTool(m_picker);

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