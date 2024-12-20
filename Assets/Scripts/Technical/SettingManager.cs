using UnityEngine;
using UnityEngine.Serialization;


public class SettingManager : Singleton<SettingManager>
{
    [SerializeField] private Settings m_setting;

    public Settings Setting => m_setting;


    public void SetSetting(Settings a_setting)
    {
        m_setting = a_setting;
    }
}