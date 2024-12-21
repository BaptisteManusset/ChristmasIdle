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
    private Toggle m_toggle;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();
        m_toggle = GetComponentInChildren<Toggle>(true);
        m_slider.onValueChanged.AddListener(SetSliderValue);
        m_toggle.onValueChanged.AddListener(Toggle);
        m_camera = Camera.main;
        m_snow = m_camera.GetComponentInChildren<ParticleSystem>(true);
        m_text = GetComponentInChildren<TMP_Text>(true);
        m_main = m_snow.main;
        m_slider.value = SettingManager.Instance.Setting.SnowflakeScale;
        m_main.startSize = m_slider.value;

        SetSliderValue(SettingManager.SNOWFLAKE_SCALE);

        SaveManager.Instance.OnLoad += OnSaveLoad;
    }

    private void OnSaveLoad()
    {
        SetSliderValue(SettingManager.Instance.Setting.SnowflakeScale);
    }

    private void Toggle(bool a_state)
    {
        m_snow.gameObject.SetActive(a_state);
        m_slider.interactable = a_state;
        SettingManager.Instance.Setting.SnowflakeScale = -1;
    }

    private void SetSliderValue(float a_value)
    {
        m_snow.gameObject.SetActive(a_value > 0);
        m_slider.interactable = a_value > 0;

        m_text.text = $"Snowflake size: {a_value:F}";
        m_main.startSize = a_value;
    }
}