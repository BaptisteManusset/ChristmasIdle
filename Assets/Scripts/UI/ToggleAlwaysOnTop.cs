using UnityEngine;
using UnityEngine.UI;

public class ToggleAlwaysOnTop : MonoBehaviour
{
    [SerializeField] private BoolRef m_value;
    private Toggle m_toggle;

    private void Awake()
    {
        m_toggle = GetComponentInChildren<Toggle>(true);
        m_toggle.isOn = SettingManager.DEFAULT_ALWAYS_ON_TOP;
        OnChange(SettingManager.DEFAULT_ALWAYS_ON_TOP);
        m_toggle.onValueChanged.AddListener(OnChange);

        SaveManager.Instance.OnLoad += OnLoad;
    }

    private void OnLoad()
    {
        OnChange(m_value.Value);
    }

    private void OnDestroy()
    {
        m_toggle.onValueChanged.RemoveListener(OnChange);
        if (SaveManager.Instance) SaveManager.Instance.OnLoad -= OnLoad;
    }

    private void OnChange(bool a_value)
    {
        if (m_value.Value == a_value) return;
        m_value.Value = a_value;
    }
}