using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<HUD>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}