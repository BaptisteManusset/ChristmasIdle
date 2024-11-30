using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListAllWindows : MonoBehaviour
{
    [SerializeField] private TMP_Text list;

    private void Start()
    {
        list.text = "";
        foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
        {
            IntPtr handle = window.Key;
            string title = window.Value;
            list.text += $"{handle}: {title}\n";
        }
    }
}