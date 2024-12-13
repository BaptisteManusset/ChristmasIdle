using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SnowflakeScaleSlider : MonoBehaviour
{
    private Slider m_slider;
    private Camera m_camera;
    private TMP_Text m_text;
    private ParticleSystem m_snow;
    private ParticleSystem.MainModule pMain;
    private Toggle m_toggle;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();
        m_toggle = GetComponentInChildren<Toggle>(true);
        m_slider.onValueChanged.AddListener(Call);
        m_toggle.onValueChanged.AddListener(Toggle);
        m_camera = Camera.main;
        m_snow = m_camera.GetComponentInChildren<ParticleSystem>(true);
        m_text = GetComponentInChildren<TMP_Text>(true);
        pMain = m_snow.main;
        Call(m_slider.value);
    }

    private void Toggle(bool a_state)
    {
        m_snow.gameObject.SetActive(a_state);
        m_slider.interactable = a_state;
    }

    private void Call(float a_value)
    {
        m_text.text = $"Snowflake size: {a_value:F}";
        pMain.startSize = a_value;
    }
}