using Appsulove.Settings;
using UniRx;

public interface IApplicationPresenter
{
    void Update();
}

public class ApplicationPresenter : IApplicationPresenter
{
    private readonly IGameplayView _gameplayView;
    private readonly IUserInterfaceView _interfaceView;
    private readonly IApplicationModel _model;
    private readonly Screens _screens;
    private readonly GameSettings _settings;

    private bool _isPause;

    public ApplicationPresenter(IGameplayView gameplayView, IUserInterfaceView uIView, IApplicationModel model, Screens screens, GameSettings settings)
    {
        _gameplayView = gameplayView;
        _interfaceView = uIView;
        _model = model;
        _screens = screens;
        _settings = settings;

        _model.DistanceRx.SubscribeToText(uIView.DistanceRxText);
    }

    void IApplicationPresenter.Update()
    {
        if (_interfaceView.Pause)
        {
            _gameplayView.SetPause(true);
            _interfaceView.ShowPause(true);
            _isPause = true;
        }

        if (!_isPause)
        {
            //TODO: put movement in FixedUpdate to avoid frame rate dependency (for physics)
            _gameplayView.Update(_interfaceView.TouchPosition);
            _interfaceView.Update(_model.Score, _model.Distance);
            _model.Update(_gameplayView.AddScore, _gameplayView.AddDistance);
        }

        if (_interfaceView.Resume)
        {
            _interfaceView.ShowPause(false);
            _gameplayView.SetPause(false);
            _isPause = false;
        }
    }
}