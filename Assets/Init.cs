using Appsulove.Settings;
using System.Collections;
using System.Collections.Generic;
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
        var interfaceView = new UIView();
        var gameplayView = new GameplayView();
        var model = new Model();

        _presenter = new Presenter(gameplayView, interfaceView, model, Screens, GameSettings);
    }

    private void Update()
    {
        _presenter.Update();
    }
}

public interface IApplicationPresenter
{
    void Update();
}

public class Presenter : IApplicationPresenter
{
    private readonly GameplayView _gameplayView;
    private readonly UIView _UIView;
    private readonly Model _model;
    private readonly Screens _screens;
    private readonly GameSettings _settings;

    public Presenter(GameplayView gameplayView, UIView uIView, Model model, Screens screens, GameSettings settings)
    {
        _gameplayView = gameplayView;
        _UIView = uIView;
        _model = model;
        _screens = screens;
        _settings = settings;
    }

    void IApplicationPresenter.Update()
    {
        throw new System.NotImplementedException();
    }
}

public class UIView : IUserInterfaceView
{

}

public interface IUserInterfaceView
{
}

public class GameplayView : IGameplayView
{

}

public interface IGameplayView
{
}