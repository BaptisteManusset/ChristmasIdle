using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_label;
    [SerializeField] private Button m_save;
    [SerializeField] private Button m_load;


    private void Awake()
    {
        m_save.onClick.AddListener(OnSave);
        m_load.onClick.AddListener(OnLoadSave);
    }

    private void OnLoadSave()
    {
        SaveManager.Instance.LoadSave();
        UpdateUI();
    }

    private void OnSave()
    {
        SaveManager.Instance.Save();
        UpdateUI();
    }

    private void OnDestroy()
    {
        m_save.onClick.RemoveListener(OnSave);
        m_load.onClick.RemoveListener(OnLoadSave);
    }

    [NaughtyAttributes.Button]
    private void UpdateUI()
    {
        if (ES3.FileExists(SaveManager.FILEPATH))
        {
            m_save.interactable = true;
            m_load.interactable = true;
        }
        else
        {
            m_save.interactable = true;
            m_load.interactable = false;
        }
    }

    private void OnEnable()
    {
        UpdateUI();
    }
}