using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button m_toggle;
    [SerializeField] private GameObject m_library;
    [SerializeField] private GameObject m_background;


    public static bool IsOpen;

    void Start()
    {
        m_toggle.onClick.AddListener(Call);
        Close();
    }

    private void Call()
    {
        if (IsOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        IsOpen = true;
        m_background.gameObject.SetActive(true);
        m_library.gameObject.SetActive(true);
    }

    private void Close()
    {
        IsOpen = false;
        m_background.gameObject.SetActive(false);
        m_library.gameObject.SetActive(false);
    }
}