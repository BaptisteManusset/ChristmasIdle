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
}