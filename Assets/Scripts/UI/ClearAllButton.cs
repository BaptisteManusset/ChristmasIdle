using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ClearAllButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image m_loader;
    [SerializeField] private float m_duration = 1;
    private float m_progress;

    private void Awake()
    {
        m_loader.fillAmount = 0;
    }

    private void Update()
    {
        if (m_progress < 0) return;
        if (m_progress > 0)
        {
            m_progress -= Time.deltaTime;
            TilemapHandler.Instance.TileMap.ClearAllTiles();
        }

        m_loader.fillAmount = 1 - m_progress / m_duration;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_progress = m_duration;
    }
}