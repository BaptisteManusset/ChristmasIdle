using UnityEngine;
using UnityEngine.UI;

public class ToggleAlwaysOnTop : MonoBehaviour
{
    private Toggle m_toggle;

    private void Awake()
    {
        m_toggle = GetComponentInChildren<Toggle>(true);
        m_toggle.isOn = SettingManager.DEFAULT_ALWAYS_ON_TOP;
        OnChange(SettingManager.DEFAULT_ALWAYS_ON_TOP);
        m_toggle.onValueChanged.AddListener(OnChange);
    }

    private void OnDestroy()
    {
        m_toggle.onValueChanged.RemoveListener(OnChange);
    }

    private void OnChange(bool a_value)
    {
        if (SettingManager.Instance.Setting.AlwaysOnTop == a_value) return;
        AlwaysOnTop.Instance.ToggleAlwaysOnTop(a_value);
        SettingManager.Instance.Setting.AlwaysOnTop = a_value;
    }
}