using UnityEngine;


public class SettingManager : Singleton<SettingManager>
{
    [SerializeField] private Settings m_setting;
    public Settings Setting => m_setting;

    public const float DEFAULT_CAMERA_SCALE = 10;
    public const float DEFAULT_SNOWFLAKE_SCALE = .01f;
    public const bool DEFAULT_ALWAYS_ON_TOP = true;


    public void SetSetting(Settings a_setting)
    {
        m_setting = a_setting;
    }
}