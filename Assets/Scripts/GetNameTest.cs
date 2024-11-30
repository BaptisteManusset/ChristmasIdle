using System;
using TMPro;
using UnityEngine;


public class GetNameTest : MonoBehaviour
{
    public TMP_Text label;

    private void Awake()
    {
        label.text = System.AppDomain.CurrentDomain.FriendlyName + "\n" +
                     System.Diagnostics.Process.GetCurrentProcess().ProcessName;
    }
}