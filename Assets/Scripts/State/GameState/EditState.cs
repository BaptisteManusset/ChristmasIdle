public class EditState : GameState
{
    public override EGameState State => EGameState.EditState;

    public override void OnEnter()
    {
        base.OnEnter();
        ToolsManager.Instance.SetPlacer();
    }
}