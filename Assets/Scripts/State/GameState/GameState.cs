public class GameState : State
{
    public virtual EGameState State => EGameState.None;

    public override void OnEnter()
    {
    }

    public override void UpdateState()
    {
    }

    public override void OnExit()
    {
    }
}