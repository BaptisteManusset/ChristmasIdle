using System;
using Technical.VarRef;
using UnityEngine;
using UnityEngine.Tilemaps;

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


    public VarEnum state => m_state;

    public T Value
    {
        get
        {
            return m_state switch
            {
                VarEnum.Value => m_varValue,
                VarEnum.Ref => m_varRef.Value,
            };
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