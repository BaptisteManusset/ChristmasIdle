using Technical.VarRef;
using TMPro;
using UnityEngine;

public class TextVarRef : MonoBehaviour
{
    [SerializeField] private string m_prefix;
    [SerializeField] private string m_suffix;

    [SerializeField] private VarRef m_ref;
    private TMP_Text m_label;


    private void Awake()
    {
        m_label = GetComponent<TMP_Text>();
        m_ref.ValueChanged += ValueChanged;
    }

    private void ValueChanged()
    {
        m_label.text = m_ref switch
        {
            FloatRef floatRef => $"{m_prefix} {floatRef.Value:0.00} {m_suffix}",
            BoolRef boolRef => $"{m_prefix} {boolRef.Value} {m_suffix}",
            TileRef tileRef => $"{m_prefix} {tileRef.Value.name} {m_suffix}",
            _ => m_label.text
        };
    }
}