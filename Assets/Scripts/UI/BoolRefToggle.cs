using UnityEngine;
using UnityEngine.UI;

public class BoolRefToggle : MonoBehaviour
{
    [SerializeField] private BoolRef m_data;
    private Toggle m_slider;

    private void Awake()
    {
        m_slider = GetComponentInChildren<Toggle>(true);
        m_slider.onValueChanged.AddListener(ToggleChange);
        m_data.ValueChanged += MDataChanged;
    }


    private void OnDestroy()
    {
        m_slider.onValueChanged.RemoveListener(ToggleChange);
        m_data.ValueChanged -= MDataChanged;
    }

    private void MDataChanged()
    {
        m_slider.isOn = m_data.Value;
    }

    private void ToggleChange(bool a_bool)
    {
        m_data.Value = a_bool;
    }
}