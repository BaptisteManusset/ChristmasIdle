using UnityEngine;

public class EditState : GameState
{
    public override EGameState State => EGameState.EditState;
    public Canvas m_toolbox;

    public override void OnEnter()
    {
        m_toolbox.enabled = true;
    }

    public override void UpdateState()
    {
    }

    public override void OnExit()
    {
        m_toolbox.enabled = false;
    }
}