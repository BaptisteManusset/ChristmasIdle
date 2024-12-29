using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnowflakeScaleSlider : MonoBehaviour
{
    private Slider m_slider;
    private Camera m_camera;
    private TMP_Text m_text;
    private ParticleSystem m_snow;
    private ParticleSystem.MainModule m_main;

    private void Awake()
    {
        m_slider = GetComponentInChildren<Slider>(true);
        m_slider.onValueChanged.AddListener(OnValueChanged);
        m_camera = Camera.main;
        m_snow = m_camera.GetComponentInChildren<ParticleSystem>(true);
        m_text = GetComponentInChildren<TMP_Text>(true);
    }

    private void OnDestroy()
    {
        m_slider.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(float a_value)
    {
        SettingManager.Instance.Setting.SnowflakeScale = a_value;
        SetSliderValue(a_value);
    }

    private void SetScale(float a_value)
    {
        m_main = m_snow.main;
        m_main.startSize = a_value;
    }

    private void SetSliderValue(float a_value)
    {
        m_text.text = $"Snowflake size: {a_value:F}";
        SetScale(a_value);
    }
}