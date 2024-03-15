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