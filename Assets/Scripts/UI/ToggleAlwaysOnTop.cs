using UnityEngine;
using UnityEngine.UI;

public class ToggleAlwaysOnTop : MonoBehaviour
{
    private Toggle m_toggle;
    private void Awake()
    {
        m_toggle = GetComponentInChildren<Toggle>(true);
        m_toggle.onValueChanged.AddListener(OnChange);
    }

    private void OnDestroy()
    {
        m_toggle.onValueChanged.RemoveListener(OnChange);
    }

    private void OnEnable()
    {
        m_toggle.isOn = SettingManager.Instance.Setting.AlwaysOnTop;
    }

    private void OnChange(bool a_value)
    {
        AlwaysOnTop.Instance.ToggleAlwaysOnTop(a_value);
        SettingManager.Instance.Setting.AlwaysOnTop = a_value;
    }
}