public class IdleState : GameState
{
    public override EGameState State => EGameState.Idle;

    public override void OnEnter()
    {
        base.OnEnter();
        ToolsManager.Instance.SetTool(null);
    }
}