using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatRefSlider : MonoBehaviour
{
    [SerializeField] private FloatRef m_value;
    private Slider m_slider;

    private void Awake()
    {
        m_slider = GetComponentInChildren<Slider>(true);
        m_slider.onValueChanged.AddListener(SliderChange);
        m_value.ValueChanged += ValueChanged;
    }


    private void OnDestroy()
    {
        m_slider.onValueChanged.RemoveListener(SliderChange);
        m_value.ValueChanged -= ValueChanged;
    }
    private void ValueChanged()
    {
        m_slider.value = m_value.Value;
    }

    private void SliderChange(float a_float)
    {
        m_value.Value = a_float;
    }
}