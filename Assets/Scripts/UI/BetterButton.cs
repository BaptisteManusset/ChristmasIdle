﻿using UnityEngine.UI;

public class BetterButton : Button
{
    private ButtonFeedback m_feedback;

    protected override void Awake()
    {
        base.Awake();
        m_feedback = GetComponent<ButtonFeedback>();
    }

    public void Select()
    {
        m_feedback.Select();
    }

    public void Deselect()
    {
        m_feedback.Deselect();
    }
}