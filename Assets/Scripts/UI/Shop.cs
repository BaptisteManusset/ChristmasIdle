public class Shop : Singleton<Shop>
{
    private void OnEnable()
    {
        ToolsManager.Instance.SetPicker();
    }

    private void OnDisable()
    {
        ToolsManager.Instance.SetPlacer();
    }
}