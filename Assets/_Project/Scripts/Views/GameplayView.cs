using Appsulove.Settings;
using UnityEngine;

public class GameplayView : IGameplayView
{
    private readonly Prefabs _prefabs;
    private readonly GameSettings _gameSettings;
    private readonly Camera _camera;
    private readonly EnemySpawner _enemySpawner;

    private Player _player;

    public GameplayView(Prefabs prefabs, GameSettings gameSettings, Camera camera)
    {
        _prefabs = prefabs;
        _gameSettings = gameSettings;
        _camera = camera;
        _enemySpawner = new EnemySpawner(prefabs, gameSettings, camera);

        SpawnPlayer();
    }

    public void Update(Vector2 touchPosition)
    {
        UpdatePlayer(touchPosition);
    }

    private void UpdatePlayer(Vector2 touchPosition)
    {
        _player.SetPosition(touchPosition, _gameSettings.PlayerSpeed);
    }

    private void SpawnPlayer()
    {
        _player = Object.Instantiate(_prefabs.Player);
    }
}
