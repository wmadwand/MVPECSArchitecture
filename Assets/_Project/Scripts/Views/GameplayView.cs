using Appsulove.Settings;
using System.Threading;
using UnityEngine;

public class GameplayView : IGameplayView
{
    //TODO: better to have only a couple of dependencies
    private readonly Prefabs _prefabs;
    private readonly GameSettings _gameSettings;
    private readonly Camera _camera;
    private readonly IEnemySpawner _enemySpawner;

    private IPlayer _player;
    private CancellationTokenSource _cts;

    public float AddDistance => _player.AddDistance;
    public int AddScore => _enemySpawner.AddScore;

    public GameplayView(Prefabs prefabs, GameSettings gameSettings, Camera camera)
    {
        _prefabs = prefabs;
        _gameSettings = gameSettings;
        _camera = camera;

        _cts = new CancellationTokenSource();
        //TODO: inject
        _enemySpawner = new EnemySpawner(prefabs, gameSettings, camera, _cts.Token);

        SpawnPlayer();
    }

    void IGameplayView.Update(Vector2 touchPosition)
    {
        UpdatePlayer(touchPosition);
        UpdateEnemies();
    }

    void IGameplayView.SetPause(bool toTrue)
    {
        Time.timeScale = toTrue ? 0f : 1f;
    }

    private void UpdatePlayer(Vector2 touchPosition)
    {
        _player.SetPosition(touchPosition, _gameSettings.PlayerSpeed, _gameSettings.PlayerPositionOffset);
    }

    private void UpdateEnemies()
    {
        _enemySpawner.Update();
    }

    private void SpawnPlayer()
    {
        _player = Object.Instantiate(_prefabs.Player);
    }

    ~GameplayView()
    {
        Stop();
    }

    public void Stop()
    {
        _cts.Cancel();
        _cts.Dispose();
        _cts = null;
    }
}
