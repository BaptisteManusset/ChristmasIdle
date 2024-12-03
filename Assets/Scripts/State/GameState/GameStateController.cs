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
}