using UnityEngine;
using UnityEngine.Tilemaps;

public class Startup : MonoBehaviour
{
    [SerializeField] private TileBase m_base;
    [SerializeField] private TileRef m_defaultTile;

    private void Awake()
    {
        m_defaultTile.Value = m_base;
    }
}