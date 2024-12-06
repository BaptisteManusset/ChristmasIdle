using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] protected Button m_button;

    public Button Button => m_button;

    protected virtual void Awake()
    {
        m_button.onClick.AddListener(OnButtonClick);
    }

    protected virtual void OnDestroy()
    {
        m_button.onClick.RemoveListener(OnButtonClick);
    }

    public virtual void OnLeftCanceled()
    {
    }

    public virtual void OnLeftPerformed()
    {
    }

    public virtual void OnLeftStarted()
    {
    }

    public virtual void OnRightCanceled()
    {
    }

    public virtual void OnRightPerformed()
    {
    }

    public virtual void OnRightStarted()
    {
    }

    public virtual void OnSelect()
    {
        Debug.Log($"<b>{GetType().Name}:{MethodBase.GetCurrentMethod()?.Name}</b>", this);
    }

    public virtual void OnDeselect()
    {
        Debug.Log($"<b>{GetType().Name}:{MethodBase.GetCurrentMethod()?.Name}</b>", this);
    }

    protected virtual void OnButtonClick()
    {
        ToolsManager.Instance.SetCurrentTool(this);
    }
}