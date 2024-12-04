using System;
using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField] private IngameState m_ingame;
    [SerializeField] private UiState m_uiState;

    private void Start()
    {
        ChangeState(m_ingame);
    }

    public void GotoUI() => ChangeState(m_uiState);
    public void GotoIngame() => ChangeState(m_ingame);
}

public enum EGameState
{
    Ingame,
    Menu,
    None
}