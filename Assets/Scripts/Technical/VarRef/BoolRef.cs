using Technical.VarRef;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolRef", menuName = "VarRef/BoolRef", order = 0)]
public class BoolRef : VarRef<bool>
{
    public static implicit operator bool(BoolRef a_value)
    {
        return a_value.Value;
    }
}