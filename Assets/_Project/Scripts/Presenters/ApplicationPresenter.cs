using Appsulove.Settings;

public interface IApplicationPresenter
{
    void Update();
}

public class ApplicationPresenter : IApplicationPresenter
{
    private readonly GameplayView _gameplayView;
    private readonly IUserInterfaceView _interfaceView;
    private readonly ApplicationModel _model;
    private readonly Screens _screens;
    private readonly GameSettings _settings;

    public ApplicationPresenter(GameplayView gameplayView, UIView uIView, ApplicationModel model, Screens screens, GameSettings settings)
    {
        _gameplayView = gameplayView;
        _interfaceView = uIView;
        _model = model;
        _screens = screens;
        _settings = settings;
    }

    void IApplicationPresenter.Update()
    {
        _gameplayView.Update(_interfaceView.TouchPosition);
        _interfaceView.Update(_model.Score, _model.Distance);
    }
}