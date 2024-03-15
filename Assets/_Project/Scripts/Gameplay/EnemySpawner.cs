using Appsulove.Settings;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface IEnemySpawner
{
    int AddScore { get; }

    void Update();
}

public class EnemySpawner : IEnemySpawner
{
    public int AddScore { get; private set; }

    private readonly Prefabs _prefabs;
    private readonly GameSettings _gameSettings;
    private readonly Camera _camera;
    private readonly List<Enemy> _collection = new List<Enemy>();

    private CancellationTokenSource _cts;

    public EnemySpawner(Prefabs prefabs, GameSettings gameSettings, Camera camera)
    {
        _prefabs = prefabs;
        _gameSettings = gameSettings;
        _camera = camera;

        _cts = new CancellationTokenSource();
        _ = Run(_cts.Token);
    }

    void IEnemySpawner.Update()
    {
        AddScore = 0;
        for (int i = 0; i < _collection.Count; i++)
        {
            var enemy = _collection[i];
            if (enemy.IsCollisionEnter)
            {
                AddScore += enemy.Score;
                _collection.RemoveAt(i);
                enemy.Remove();
            }
        }
    }

    //TODO: run from Gameplayview & Presenter + pass CancellationToken
    //TODO: pass isPause state
    private async UniTask Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (_collection.Count < _gameSettings.EnemyMaxCount /*&& !isPause*/)
            {
                Spawn();

                await UniTask.Delay(_gameSettings.EnemySpawnRate * 100, cancellationToken: token);
            }

            await UniTask.Yield(cancellationToken: token);
        }
    }

    private Vector3 GetRandomPosition()
    {
        var offset = _gameSettings.EnemyPositionOffset;
        var xRnd = Random.Range(offset, Screen.width - offset);
        var yRnd = Random.Range(offset, Screen.height - offset);
        var position = Camera.main.ScreenToWorldPoint(new Vector2(xRnd, yRnd));
        position.z = 0;

        return position;
    }

    private void Spawn()
    {
        var enemy = CreateEnemy();
        enemy.Score = Random.Range(10, 50);
        _collection.Add(enemy);
    }

    private Enemy CreateEnemy()
    {
        var rndPosition = GetRandomPosition();
        var instance = Object.Instantiate(_prefabs.Enemy, rndPosition, Quaternion.identity);

        return instance;
    }
}
