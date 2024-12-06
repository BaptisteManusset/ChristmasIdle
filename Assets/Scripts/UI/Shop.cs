using UnityEngine;
using UnityEngine.UI;

public class Shop : Singleton<Shop>
{
    [SerializeField] private Button m_toggle;
    [SerializeField] private GameObject m_library;
    [SerializeField] private GameObject m_background;


    public static bool IsOpen;

    private void Start()
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
        ((GameStateController)GameStateController.Instance).GotoUI();
        
        IsOpen = true;
        m_background.gameObject.SetActive(true);
        m_library.gameObject.SetActive(true);
        ToolsManager.Instance.SetPicker();
    }

    private void Close()
    {
        ((GameStateController)GameStateController.Instance).GotoIngame();
        IsOpen = false;
        m_background.gameObject.SetActive(false);
        m_library.gameObject.SetActive(false);
    }
}