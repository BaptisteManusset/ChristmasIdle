public class ShopState : GameState
{
    public override EGameState State => EGameState.Menu;

    public override void OnEnter()
    {
        base.OnEnter();
        TilemapHandler.Instance.SwitchTilemap(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        TilemapHandler.Instance.SwitchTilemap(false);
    }
}