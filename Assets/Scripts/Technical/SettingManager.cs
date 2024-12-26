using UnityEngine;


public class SettingManager : Singleton<SettingManager>
{
    [SerializeField] private Settings m_setting;

    public Settings Setting => m_setting;

    public const float CAMERA_SCALE = 10;
    public const float SNOWFLAKE_SCALE = .01f;


    public void SetSetting(Settings a_setting)
    {
        m_setting = a_setting;
    }
}