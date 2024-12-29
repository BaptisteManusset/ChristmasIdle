﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraScaleSlider : MonoBehaviour
{
    private Slider m_slider;
    private Camera m_camera;
    private TMP_Text m_text;
    private ParticleSystem m_snow;

    [SerializeField] private FloatRef m_floatRef;

    private void Awake()
    {
        m_slider = GetComponentInChildren<Slider>(true);
        m_slider.onValueChanged.AddListener(ValueChange);
        m_camera = Camera.main;
        m_snow = m_camera.GetComponentInChildren<ParticleSystem>(true);
        m_text = GetComponentInChildren<TMP_Text>(true);
        m_slider.value = m_floatRef.Value;
        SetSliderValue(SettingManager.DEFAULT_CAMERA_SCALE);
    }


    private void ValueChange(float a_value)
    {
        m_floatRef.Value = a_value;
        SetSliderValue(a_value);
    }

    private void SetSliderValue(float a_value)
    {
        m_camera.orthographicSize = a_value;
        m_snow.transform.position = new Vector3(0, a_value, 0);
        m_text.text = $"Camera size: {a_value}";
        m_snow.transform.localScale = new Vector3(a_value * 4, 1, 1);
    }
}