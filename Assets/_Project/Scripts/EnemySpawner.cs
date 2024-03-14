using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public int maxCount = 15;
    public int spawnRate = 2;

    List<Enemy> collection = new List<Enemy>();

    CancellationTokenSource cts;

    private void Start()
    {
        cts = new CancellationTokenSource();
        Player.OnDestroyEnemy += Player_OnDestroyEnemy;

        _ = Run(cts.Token);
    }

    private void Player_OnDestroyEnemy(Enemy obj)
    {
        collection.Remove(obj);
        Destroy(obj.gameObject);
    }

    private async UniTask Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (collection.Count < maxCount)
            {
                Spawn();

                await UniTask.Delay(spawnRate * 100, cancellationToken: token);
            }

            await UniTask.Yield(cancellationToken: token);
        }
    }

    private Vector3 GetRandomPosition()
    {
        var offset = 5;
        var xRnd = Random.Range(offset, Screen.width - offset);
        var yRnd = Random.Range(offset, Screen.height - offset);

        var pos = Camera.main.ScreenToWorldPoint(new Vector3(xRnd, yRnd, 0));
        pos.z = 0;
        return pos;
    }

    private void Spawn()
    {
        var newEnemy = CreateEnemy();
        newEnemy.Score = Random.Range(10, 50);
        collection.Add(newEnemy);
    }


    private Enemy CreateEnemy()
    {
        var rndPosition = GetRandomPosition();
        var instance = Instantiate(enemyPrefab, rndPosition, Quaternion.identity, transform);
        return instance;
    }
}
