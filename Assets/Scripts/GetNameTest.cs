using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;


public class GetNameTest : MonoBehaviour
{
    public TMP_Text label;

    private void Awake()
    {
#if UNITY_EDITOR
        label.text = AppDomain.CurrentDomain.FriendlyName + "\n" +
                     Process.GetCurrentProcess().ProcessName;
#endif
    }
}