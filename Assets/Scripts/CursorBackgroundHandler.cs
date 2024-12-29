using UnityEngine;

public class CursorBackgroundHandler : Singleton<CursorBackgroundHandler>
{
    [SerializeField] private GameObject m_placement;


    public void Hide()
    {
        m_placement.SetActive(false);
    }

    public void SetPosition(Vector3Int a_position)
    {
        m_placement.transform.position = a_position;
    }

    public void Show()
    {
        m_placement.SetActive(true);
    }
}
