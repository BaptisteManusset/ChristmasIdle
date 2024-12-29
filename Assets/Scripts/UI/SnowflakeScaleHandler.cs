using UnityEngine;

public class SnowflakeScaleHandler : MonoBehaviour
{
    [SerializeField] private FloatRef m_floatRef;
    private ParticleSystem m_snow;
    private ParticleSystem.MainModule m_main;

    private void Awake()
    {
        m_snow = GetComponentInChildren<ParticleSystem>(true);
        m_floatRef.ValueChanged += SetScale;
    }

    private void OnDestroy()
    {
        m_floatRef.ValueChanged -= SetScale;
    }

    private void SetScale() => SetScale(m_floatRef.Value);

    private void SetScale(float a_value)
    {
        m_main = m_snow.main;
        m_main.startSize = a_value;
    }
}