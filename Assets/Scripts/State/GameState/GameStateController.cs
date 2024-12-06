using System;
using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField]
    private EditState m_edit;

    [SerializeField] private ShopState m_uiState;
    [SerializeField] private IdleState m_idleState;

    public event Action<EGameState> OnGameStateChanged;

    private void Start()
    {
        ChangeState(m_idleState);
    }

    public void GotoUI() => ChangeState(m_uiState);
    public void GotoIngame() => ChangeState(m_edit);
    public void GotoIdle() => ChangeState(m_idleState);

    public override void ChangeState(GameState a_newState)
    {
        base.ChangeState(a_newState);
        OnGameStateChanged?.Invoke(a_newState.State);
    }
}

public enum EGameState
{
    EditState,
    Menu,
    None,
    Idle
}