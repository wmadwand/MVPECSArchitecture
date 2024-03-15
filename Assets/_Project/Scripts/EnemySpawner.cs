using Appsulove.Settings;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner
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

        Player.OnDestroyEnemy += Player_OnDestroyEnemy;
    }

    public void Update()
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

    private void Player_OnDestroyEnemy(Enemy obj)
    {
        _collection.Remove(obj);
        Object.Destroy(obj.gameObject);
    }

    //TODO: run from Gameplayview & Presenter
    private async UniTask Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (_collection.Count < _gameSettings.EnemyMaxCount)
            {
                Spawn();

                await UniTask.Delay(_gameSettings.EnemySpawnRate * 100, cancellationToken: token);
            }

            await UniTask.Yield(cancellationToken: token);
        }
    }

    private Vector3 GetRandomPosition()
    {
        var offset = 25;
        var xRnd = Random.Range(offset, Screen.width - offset);
        var yRnd = Random.Range(offset, Screen.height - offset);

        var pos = Camera.main.ScreenToWorldPoint(new Vector3(xRnd, yRnd, 0));
        pos.z = 0;
        return pos;
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
