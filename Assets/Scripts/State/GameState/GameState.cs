using UnityEngine;
using UnityEngine.Serialization;

public class GameState : State
{
    public virtual EGameState State => EGameState.None;
    public Canvas UI;

    public virtual void Awake()
    {
        UI.enabled = false;
    }

    public override void OnEnter()
    {
        UI.enabled = true;
    }

    public override void UpdateState()
    {
    }

    public override void OnExit()
    {
        UI.enabled = false;
    }
}