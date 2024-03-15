using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Camera Camera;

    public override void InstallBindings()
    {
        Container.Bind<UserDataLocalStorage>().AsSingle().NonLazy();
        Container.BindInstance(Camera).AsSingle();

        // Sample01 just for the test-task
        //// For Enemy we could use Factory + pooling object
        ///  [SerializeField] private GameObject _enemyTemplate;
        //Container.BindFactory<Vector3, Enemy, Enemy.Factory>()
        //         .FromPoolableMemoryPool<Vector3, Enemy, EnemyPool>(poolBinder => poolBinder
        //         .WithInitialSize(5)
        //         .FromComponentInNewPrefab(_enemyTemplate)
        //         .UnderTransformGroup("Enemies"));
        //class EnemyPool : MonoPoolableMemoryPool<Vector3, IMemoryPool, Enemy> { }


        // Sample02 just for the test-task
        //Container.BindFactory<ProjectileBase, ProjectileBase.Factory>().WithId(HazardType.Comet)
        // .FromComponentInNewPrefab(_cometTemplate)
        // .UnderTransformGroup("Hazards");
    }
}