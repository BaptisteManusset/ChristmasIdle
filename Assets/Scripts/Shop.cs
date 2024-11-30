using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button m_toggle;
    private bool toggle;

    private float width;

    void Start()
    {
        m_toggle.onClick.AddListener(Call);

        width = ((RectTransform)transform).rect.width;

        Close();
    }

    private void Call()
    {
        if (toggle)
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
        Vector3 pos = transform.position;
        pos.x = 0;
        transform.position = pos;
        toggle = true;
    }

    private void Close()
    {
        Vector3 pos = transform.position;
        pos.x = -width;
        transform.position = pos;
        toggle = false;

    }
}