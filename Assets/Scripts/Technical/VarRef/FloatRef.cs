using Technical.VarRef;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatRef", menuName = "VarRef/FloatRef", order = 0)]
public class FloatRef : VarRef<float>
{
    public static implicit operator float(FloatRef a_value)
    {
        return a_value.Value;
    }
}