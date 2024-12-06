using UnityEngine;
using UnityEngine.Serialization;

public class IdleState : GameState
{
    public override EGameState State => EGameState.Idle;
    public Canvas m_ui;

    public override void OnEnter()
    {
        m_ui.enabled = true;
    }

    public override void UpdateState()
    {
    }

    public override void OnExit()
    {
        m_ui.enabled = false;
    }
}