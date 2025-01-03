using System;
using UnityEngine;

public class ButtonFeedback : MonoBehaviour
{
    private BetterButton m_betterButton;
    [SerializeField] public Sprite m_defaultSprite;
    [SerializeField] public Sprite m_selectSprite;
    public static event Action<BetterButton> OnSelectChange;


    private void Awake()
    {
        m_betterButton = GetComponent<BetterButton>();
        m_betterButton.image.sprite = m_defaultSprite;

        m_betterButton.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        OnSelectChange += OnSelectChanged;
    }

    private void OnDestroy()
    {
        OnSelectChange -= OnSelectChanged;
    }

    private void OnClick()
    {
        OnSelectChange?.Invoke(m_betterButton);
    }

    private void OnSelectChanged(BetterButton a_button)
    {
        if (m_betterButton == a_button)
        {
            Select();
            return;
        }

        Deselect();
    }

    public void Select()
    {
        m_betterButton.image.sprite = m_selectSprite;
        AudioHandler.Instance.ClickSound();
    }

    public void Deselect()
    {
        if (!m_betterButton) m_betterButton = GetComponent<BetterButton>();
        m_betterButton.image.sprite = m_defaultSprite;
    }
}