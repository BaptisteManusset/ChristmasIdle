using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    private Button m_button;
    private TMP_Text m_text;
    private int count = 0;

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_text = m_button.GetComponentInChildren<TMP_Text>();
        m_button.onClick.AddListener(Call);
    }

    private void Call()
    {
        count++;
        m_text.text = $"{count}";
    }
}