using Appsulove.Settings;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private GameSettings GameSettings;
    [SerializeField] private Prefabs Prefabs;
    [SerializeField] private Screens Screens;
    [SerializeField] private Camera Camera;

    private IApplicationPresenter _presenter;

    private void Start()
    {
        var interfaceView = new UIView(Screens);
        var gameplayView = new GameplayView(Prefabs, GameSettings, Camera);
        var model = new ApplicationModel();

        _presenter = new ApplicationPresenter(gameplayView, interfaceView, model, Screens, GameSettings);
    }

    private void Update()
    {
        _presenter.Update();
    }
}



public class UIView : IUserInterfaceView
{
    private readonly Screens _screens;

    public UIView(Screens screens)
    {
        _screens = screens;
    }

    public Vector2 TouchPosition => _screens.HUD.TouchScreen.TouchPosition;
}

public interface IUserInterfaceView
{
}

public interface IGameplayView
{
}