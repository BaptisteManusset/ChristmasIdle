using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UiUtils : Singleton<UiUtils>
{
    public static event Action OnEnterUi;
    public static event Action OnExitUi;

    [SerializeField] private bool m_isHover;
    private static bool m_previousIsHover;

    public static bool IsHover => Instance.m_isHover;

    private bool IsHoverUI()
    {
        PointerEventData pointerEventData = new(EventSystem.current)
        {
            position = Mouse.current.position.ReadValue()
        };
        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
        for (int i = 0; i < raycastResultsList.Count; i++)
        {
            if (raycastResultsList[i].gameObject != null)
            {
                return true;
            }
        }

        return false;
    }

    private void Update()
    {
        m_isHover = IsHoverUI();

        if (m_isHover == m_previousIsHover) return;

        if (m_isHover)
        {
            OnEnterUi?.Invoke();
        }
        else
        {
            OnExitUi?.Invoke();
        }

        m_previousIsHover = m_isHover;
    }
}