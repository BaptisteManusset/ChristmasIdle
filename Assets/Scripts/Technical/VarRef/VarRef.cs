using System;
using UnityEngine;

namespace Technical.VarRef
{

    public abstract class VarRef : ScriptableObject
    {
        public virtual event Action ValueChanged;

        protected void CallEvent()
        {
            ValueChanged?.Invoke();
        }

    }
    public class VarRef<T> : VarRef

    {
        [SerializeField] private T m_value;

        public T Value
        {
            get => m_value;
            set
            {
                m_value = value;
                CallEvent();
            }
        }
    }
}