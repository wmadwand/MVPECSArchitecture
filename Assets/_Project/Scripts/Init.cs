using Appsulove.Settings;
using UnityEngine;
using Zenject;

public class Init : MonoBehaviour
{
    [SerializeField] private GameSettings GameSettings;
    [SerializeField] private Prefabs Prefabs;
    [SerializeField] private Screens Screens;
    [SerializeField] private Camera Camera;

    private UserDataLocalStorage _userDataStorage;
    private IApplicationPresenter _presenter;
    private IApplicationModel _model;

    [Inject]
    private void Construct(UserDataLocalStorage userDataStorage, Camera camera)
    {
        _userDataStorage = userDataStorage;
    }

    private void Start()
    {
        var interfaceView = new UIView(Screens);
        var gameplayView = new GameplayView(Prefabs, GameSettings, Camera);
        _model = new ApplicationModel(_userDataStorage);

        _presenter = new ApplicationPresenter(gameplayView, interfaceView, _model);
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