using System;
using Technical.VarRef;
using UnityEngine;
using UnityEngine.Tilemaps;
using Object = UnityEngine.Object;

[Serializable]
public class VarContainer
{
    public virtual event Action ValueChanged;

    protected void CallEvent()
    {
        ValueChanged?.Invoke();
    }

    public enum VarEnum
    {
        Value,
        Ref
    }
}

[Serializable]
public class VarContainer<T> : VarContainer
{
    [SerializeField] private VarEnum m_state = VarEnum.Ref;

    [SerializeField] private T m_varValue;
    [SerializeField] private VarRef<T> m_varRef;


    public VarEnum State => m_state;

    public override event Action ValueChanged
    {
        add
        {
            if (!m_varRef) return;
            m_varRef.ValueChanged += value;
        }
        remove
        {
            if (!m_varRef) return;
            m_varRef.ValueChanged -= value;
        }
    }

    public T Value
    {
        get
        {
            switch (m_state)
            {
                case VarEnum.Value:
                    return m_varValue;
                case VarEnum.Ref:
                    return m_varRef.Value;
                default:
                    return m_varValue;
            }
        }
        set
        {
            switch (m_state)
            {
                case VarEnum.Value:
                    m_varValue = value;
                    break;
                case VarEnum.Ref:
                    m_varRef.Value = value;
                    break;
                default:
                    m_varValue = value;
                    break;
            }

            CallEvent();
        }
    }
}


[Serializable]
public class FloatContainer : VarContainer<float>
{
}

[Serializable]
public class BoolContainer : VarContainer<bool>
{
}

[Serializable]
public class TileContainer : VarContainer<TileBase>
{
}