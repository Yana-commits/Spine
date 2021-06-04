using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<HUD>().FromComponentInHierarchy().AsSingle().NonLazy();

        //Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<Enemy>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<SnowBallPool>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}