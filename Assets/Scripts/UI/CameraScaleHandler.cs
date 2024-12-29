using UnityEngine;

public class CameraScaleHandler : MonoBehaviour
{
    private Camera m_camera;
    private ParticleSystem m_snow;

    [SerializeField] private FloatRef m_floatRef;

    private void Awake()
    {
        m_camera = GetComponent<Camera>();
        m_snow = GetComponentInChildren<ParticleSystem>(true);
        ValueChange(SettingManager.DEFAULT_CAMERA_SCALE);
        SaveManager.Instance.OnLoad += OnLoad;
        m_floatRef.ValueChanged += OnLoad;
    }

    private void OnDestroy()
    {
        SaveManager.Instance.OnLoad -= OnLoad;
        m_floatRef.ValueChanged -= OnLoad;
    }

    private void OnLoad()
    {
        ValueChange(m_floatRef);
    }


    private void ValueChange(float a_value)
    {
        m_camera.orthographicSize = a_value;
        m_snow.transform.position = new Vector3(0, a_value, 0);
        m_snow.transform.localScale = new Vector3(a_value * 4, 1, 1);
    }
}