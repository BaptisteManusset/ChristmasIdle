using UnityEngine;
using UnityEngine.Serialization;

public class IdleState : GameState
{
    public override EGameState State => EGameState.Idle;
}