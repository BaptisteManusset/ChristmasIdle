using UnityEngine;

public class GameState : State
{
    public virtual EGameState State => EGameState.None;
    public GameObject UI;

    public virtual void Awake()
    {
        UI.SetActive(false);
    }

    public override void OnEnter()
    {
        UI.SetActive(true);
    }

    public override void UpdateState()
    {
    }

    public override void OnExit()
    {
        UI.SetActive(false);
    }
}