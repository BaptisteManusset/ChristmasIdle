using UnityEngine;
using UnityEngine.Tilemaps;

public class Startup : MonoBehaviour
{
    [SerializeField] private TileBase m_base;
    [SerializeField] private TileRef m_defaultTile;

    [SerializeField] private BoolRef m_alwaysOnTopRef;
    private void Awake()
    {
        m_defaultTile.Value = m_base;
        m_alwaysOnTopRef.Value = SettingManager.DEFAULT_ALWAYS_ON_TOP;
    }
}