using System.Reflection;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
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
}