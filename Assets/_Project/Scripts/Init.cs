using Appsulove.Settings;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private GameSettings GameSettings;
    [SerializeField] private Prefabs Prefabs;
    [SerializeField] private Screens Screens;
    [SerializeField] private Camera Camera;

    private IApplicationPresenter _presenter;
    private IApplicationModel _model;

    private void Start()
    {
        var interfaceView = new UIView(Screens);
        var gameplayView = new GameplayView(Prefabs, GameSettings, Camera);
        _model = new ApplicationModel();

        _presenter = new ApplicationPresenter(gameplayView, interfaceView, _model, Screens, GameSettings);
    }

    private void Update()
    {
        _presenter.Update();
    }

    private void OnApplicationQuit()
    {
        _model.Save();
    }
}