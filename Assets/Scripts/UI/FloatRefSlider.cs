using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FloatRefSlider : MonoBehaviour
{

    [FormerlySerializedAs("m_value")] [SerializeField] private FloatContainer m_data;
    private Slider m_slider;

    private void Awake()
    {
        m_slider = GetComponentInChildren<Slider>(true);
        m_slider.onValueChanged.AddListener(SliderChange);
        m_data.ValueChanged += MDataChanged;
    }


    private void OnDestroy()
    {
        m_slider.onValueChanged.RemoveListener(SliderChange);
        m_data.ValueChanged -= MDataChanged;
    }
    private void MDataChanged()
    {
        m_slider.value = m_data.Value;
    }

    private void SliderChange(float a_float)
    {
        m_data.Value = a_float;
    }
}